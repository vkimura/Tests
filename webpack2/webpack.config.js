const path = require('path');
// const { SquooshPlugin } = require("squoosh-webpack-plugin");

module.exports = {
    mode: 'development',
    entry: {
        app: './src/index.js',
    },
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'public'),
        clean: true,
    },
    experiments: {
        topLevelAwait: true,
    },
    resolve: {
        fallback: {
            "path": false,
        },
    },

        
    // devtool: 'source-map',
    // devServer: {
    //     static: path.resolve(__dirname, 'dist'),
    // },
    // plugins: [
    //     new HtmlWebpackPlugin({
    //         title: 'Development',
    //         inject: 'body',
    //         template: path.resolve(__dirname, 'dist/index.html'),
    //         filename: 'index.html',
    //         minify: {
    //             collapseWhitespace: true,
    //             removeComments: true,
    //             removeRedundantAttributes: true,
    //             removeScriptTypeAttributes: true,
    //             removeStyleLinkTypeAttributes: true,
    //         }
    //     }),
    // ],
}