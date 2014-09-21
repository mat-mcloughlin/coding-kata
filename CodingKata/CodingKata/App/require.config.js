var require = {
    baseUrl: ".",
    paths: {
        "bootstrap": "App/Lib/bootstrap",
        "crossroads": "App/Lib/crossroads",
        "hasher": "App/Lib/hasher",
        "jquery": "App/Lib/jquery",
        "knockout": "App/Lib/knockout",
        "text": "App/Lib/text",
        "signals": "App/Lib/signals"

    },
    shim: {
        "bootstrap": { deps: ["jquery"] }
    }
};
