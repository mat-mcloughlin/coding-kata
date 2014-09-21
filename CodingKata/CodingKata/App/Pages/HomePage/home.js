define(['App/config', 'jquery', 'knockout', 'text!./home.html'], function (config, $, ko, homeTemplate) {

    function HomeViewModel(route) {
        var self = this;
        self.people = ko.observableArray();

        $.get(config.apiUrl + '/Person', function (data) {
            self.people(data);
        });
    }

    return { viewModel: HomeViewModel, template: homeTemplate };
});
