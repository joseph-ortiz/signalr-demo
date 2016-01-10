(function() {

    var perfHub = $.connection.perfHub; //perfHub gets created in a proxy file
    $.connection.hub.logging = true; //allows logging to the console
    $.connection.hub.start(); // start communication

    perfHub.client.newMessage = function(message) {
        model.addMessage(message);
    };

    var Model = function() {
        var self = this;
        self.message = ko.observable(""),
        self.messages = ko.observableArray()
    };

    Model.prototype = {
        
        sendMessage: function() {
            var self = this;
            perfHub.server.send(self.message());
            self.message("");
        },

        addMessage: function(message) {
            var self = this;
            self.messages.push(message);
        }

    };

    var model = new Model();
    $(function() {
        ko.applyBindings(model);
    });

}());