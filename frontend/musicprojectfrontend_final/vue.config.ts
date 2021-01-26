//WEBPACK CONFIG

module.exports = {
  pluginOptions: { webpackBundleAnalyzer: { openAnalyzer:true,     },
  // ...other vue-cli plugin options...
  pwa: {
    name: 'musicproject',
    themeColor: '#4D4D4D',
    msTileColor: '#000000',
    appleMobileWebAppCapable: 'yes',
    appleMobileWebAppStatusBarStyle: 'black-translucent',
    icons: [
      {
        "src": "./public/logo.svg",
        "sizes": "192x192",
        "type": "image/png"
      }]

    // configure the workbox plugin
    // workboxPluginMode: 'InjectManifest',
    // workboxOptions: {
      // swSrc is required in InjectManifest mode.
    //   swSrc: 'dev/sw.js',
      // ...other Workbox options...
    // }
  },
  baseUrl: '',

  }
}