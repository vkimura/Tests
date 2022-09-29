const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
// const CleanWebpackPlugin = require('clean-webpack-plugin');

module.exports = {
  entry: path.resolve(__dirname, './src/index.js'),
  output: {
    path: path.resolve(__dirname, './dist'),
    filename: '[name].bundle.js',
    clean: true,
  },
  devtool: 'source-map',
  devServer: {
    // contentBase: path.resolve(__dirname, './dist'),
    static: path.resolve(__dirname, './dist'),
  },
  plugins: [
    new HtmlWebpackPlugin({
      title: 'Development',
      inject: 'body',
      template: path.resolve(__dirname, './dist/index.html'),
      filename: 'index.html',
      minify: {
        collapseWhitespace: true,
        removeComments: true,
        removeRedundantAttributes: true,
        removeScriptTypeAttributes: true,
        removeStyleLinkTypeAttributes: true,
      }
    }),
    // new CleanWebpackPlugin(['dist']),
  ],
}

// const CompressionPlugin = require("compression-webpack-plugin");
// const zlib = require("zlib");

// module.exports = {
//   plugins: [
//     new CompressionPlugin({
//       filename: "[path][base].br",
//       algorithm: "brotliCompress",
//       test: /\.(js|css|html|svg)$/,
//       compressionOptions: {
//         params: {
//           [zlib.constants.BROTLI_PARAM_QUALITY]: 11,
//         },
//       },
//       threshold: 10240,
//       minRatio: 0.8,
//       deleteOriginalAssets: false,
//     }),
//   ],
// };

// const BrotliPlugin = require("brotli-webpack-plugin");

// module.exports = {
//   plugins: [
//     new BrotliPlugin({
//       asset: "[path].br[query]",
//       algorithm: "brotli",
//       test: /\.(js|css|html|svg)$/,
//       threshold: 10240,
//       minRatio: 0.8
//     })
//   ]
// };