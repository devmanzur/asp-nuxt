using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.SpaServices;

namespace SimpleCart.Web.Utils;

public static class NuxtIntegration
{
    private static int Port { get; } = 3000;
    private static Uri DevelopmentServerEndpoint { get; } = new Uri($"http://localhost:{Port}");
    public const string SpaSource = "ClientApplication";
    private static TimeSpan Timeout { get; } = TimeSpan.FromSeconds(30);

    // done message of 'npm run dev' command.
    private static string DoneMessage { get; } = "DONE  Compiled successfully in";

    public static void UseNuxtDevelopmentServer(this ISpaBuilder spa)
    {
        spa.UseProxyToSpaDevelopmentServer(async () =>
        {
            var loggerFactory = spa.ApplicationBuilder.ApplicationServices.GetService<ILoggerFactory>();
            var logger = loggerFactory?.CreateLogger("Nuxt");
            // if 'npm dev' command was executed yourself, then just return the endpoint.
            if (IsRunning())
            {
                return DevelopmentServerEndpoint;
            }

            // launch Nuxt development server
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var processInfo = new ProcessStartInfo
            {
                FileName = isWindows ? "cmd" : "npm",
                Arguments = $"{(isWindows ? "/c npm " : "")}run dev",
                WorkingDirectory = "ClientApplication",
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };
            var process = Process.Start(processInfo);
            var tcs = new TaskCompletionSource<int>();
            _ = Task.Run(() =>
            {
                try
                {
                    string? line;
                    while ((line = process?.StandardOutput?.ReadLine()) != null)
                    {
                        logger?.LogInformation("Output : {OutputDetails}", line);
                        if (!tcs.Task.IsCompleted && line.Contains(DoneMessage))
                        {
                            tcs.SetResult(1);
                        }
                    }
                }
                catch (EndOfStreamException ex)
                {
                    logger?.LogError("Error : {Details}", ex.ToString());
                    tcs.SetException(new InvalidOperationException("'npm run dev' failed.", ex));
                }
            });
            _ = Task.Run(() =>
            {
                try
                {
                    string? line;
                    while ((line = process?.StandardError?.ReadLine()) != null)
                    {
                        logger?.LogError("Error : {Details}", line);
                    }
                }
                catch (EndOfStreamException ex)
                {
                    logger?.LogError("Error : {Details}", ex.ToString());
                    tcs.SetException(new InvalidOperationException("'npm run dev' failed.", ex));
                }
            });

            var timeout = Task.Delay(Timeout);
            if (await Task.WhenAny(timeout, tcs.Task) == timeout)
            {
                throw new TimeoutException();
            }

            return DevelopmentServerEndpoint;
        });
    }

    private static bool IsRunning() => IPGlobalProperties.GetIPGlobalProperties()
        .GetActiveTcpListeners()
        .Select(x => x.Port)
        .Contains(Port);
}