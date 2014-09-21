define(['jquery', 'knockout', './router', 'bootstrap'], function ($, ko, router) {
    ko.components.register('home-page', { require: 'App/Pages/HomePage/home' });
    ko.components.register('edit-page', { require: 'App/Pages/EditPage/edit' });

    ko.applyBindings({ route: router.currentRoute });
});
