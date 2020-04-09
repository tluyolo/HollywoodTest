$(function () {
    ko.applyBindings(modelView);    
    modelView.viewTournament();
});

var modelView = {
    Employees: ko.observableArray([]),
    viewTournaments: function () {
        var thisObj = this;
        try {
            $.ajax({
                url: '/Tournament/ListEmployees',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    thisObj.Tournament(data);//Here we are assigning values to KO Observable array
                },
                error: function (err) {
                    alert(err.status + " : " + err.statusText);
                }

            });
        } catch (e) {
            window.location.href = '/Tournaments/Index';
        }mployee
    },
    //Create
    TournamentID: ko.observable(),
   TournamentName: ko.observable(),
   
    createTournament: function () {
        try {
            $.ajax({
                url: '/Tournaments/CreateTournament',
                type: 'POST',
                dataType: 'json',
                data: ko.toJSON(this), //Here the data wil be converted to JSON
                contentType: 'application/json',
                success: successCallback,
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/Tournaments/Index';
        }
    }//End create  
}

function successCallback(data) {
    window.location.href = '/Tournaments/Index/';
}
function errorCallback(err) {
    window.location.href = '/Tournaments/Index/';
}