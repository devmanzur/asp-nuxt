namespace SimpleCart.Web.Models
{
    public class Envelope<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public static Envelope<T> Ok(T? data = null, string message = "Success")
        {
            return new Envelope<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static Envelope<T> Error(string message = "An error occurred", T? data = null)
        {
            return new Envelope<T>
            {
                Success = false,
                Message = message,
                Data = data
            };
        }
    }
}