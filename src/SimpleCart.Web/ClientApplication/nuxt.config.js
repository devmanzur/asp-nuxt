export default {
  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: 'simple-cart',
    htmlAttrs: {
      lang: 'en',
    },
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' },
      { name: 'format-detection', content: 'telephone=no' },
    ],
    link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
  },

  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [
    // https://go.nuxtjs.dev/eslint
    '@nuxtjs/eslint-module',
    // https://go.nuxtjs.dev/tailwindcss
    '@nuxtjs/tailwindcss',
  ],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/axios
    '@nuxtjs/axios',
    '@nuxtjs/auth-next',
  ],

  // Axios module configuration: https://go.nuxtjs.dev/config-axios
  axios: {
    // Workaround to avoid enforcing hard-coded localhost:3000: https://github.com/nuxt-community/axios-module/issues/308
    baseURL: '/api/',
  },

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {},
  auth: {
    redirect: {
      login: '/',
      callback: '/auth',
    },
    cookie: {
      prefix: 'auth.',
      options: {
        path: '/',
        secure: false,
      },
    },
    strategies: {
      aad: {
        scheme: 'oauth2',
        endpoints: {
          authorization:
            'https://login.microsoftonline.com/common/oauth2/v2.0/authorize',
          token:
            'https://login.microsoftonline.com/common/oauth2/v2.0/token',
          userInfo: '',
          logout: '/',
        },
        token: {
          property: 'access_token',
          type: 'Bearer',
          maxAge: 60 * 30,
        },
        refreshToken: {
          property: 'refresh_token',
          maxAge: 60 * 60 * 24 * 30,
        },
        responseType: 'code',
        grantType: 'authorization_code',
        accessType: 'offline',
        clientId: process.env.IDENTITY_CLIENT_ID,
        codeChallengeMethod: 'S256',
        scope: ['openid', 'profile'],
        autoLogout: true,
      },
    },
  },
};
