define(['jquery', 'knockout', './router', 'bootstrap'], function ($, ko, router) {
    ko.components.register('home-page', { require: 'App/Pages/HomePage/home' });

    ko.applyBindings({ route: router.currentRoute });
});
