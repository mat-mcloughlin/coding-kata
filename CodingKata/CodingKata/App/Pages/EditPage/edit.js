define(['App/config', 'jquery', 'knockout', 'text!./edit.html'], function (config, $, ko, editTemplate) {

    function EditViewModel(route) {
        var self = this;
        self.colours = ko.observableArray();
        self.test = ko.observableArray(['test']);
        self.person = ko.observable({
            id: 0,
            name: ko.observable(),
            isAuthorised: ko.observable(false),
            isEnabled: ko.observable(false),
            colours: ko.observableArray([])
        });

        self.attachToggleEvent = function () {
            $('[data-toggle-element]').click(function () {
                var selector = $(this).data('toggle-element');
                $(selector).toggle();
            });
        }

        self.submitForm = function () {
            var data = ko.toJSON(self.person);
            $.ajax({
                type: 'POST',
                url: config.apiUrl + '/Person',
                data: data,
                contentType: 'application/json'
            }).done(function () {
                window.location.hash = '';
            });
        };

        if (route.id) {
            $.when(
                $.get(config.apiUrl + '/Person/' + route.id),
                $.get(config.apiUrl + '/colour')).done(function (personResponse, colourResponse) {
                    self.person().id = personResponse[0].id;
                    self.person().name(personResponse[0].name);
                    self.person().isAuthorised(personResponse[0].isAuthorised);
                    self.person().isEnabled(personResponse[0].isEnabled);
                    $.each(personResponse[0].colours, function (index, value) {
                        self.person().colours.push(value.toString());
                    });

                    self.colours(colourResponse[0]);

                    self.attachToggleEvent();
                });
        }

    }

    return { viewModel: EditViewModel, template: editTemplate };
});
