var parsedSelectedTournament = $.parseJSON(selectedTournament);

$(function () {
    ko.applyBindings(modelUpdate);        
});

var modelUpdate = {
    //Update
    TournamentID: ko.observable(parsedSelectedTournament.TournamentID),
    TournamentName: ko.observable(parsedSelectedTournament.TournamentName),

    updateTournament: function () {
        try {
            $.ajax({
                url: '/Tournaments/Update',
                type: 'POST',
                dataType: 'json',
                data: ko.toJSON(this),
                contentType: 'application/json',
                success: successCallback,
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/Tournaments/Index/';
        }
    }
    //End update here   
}

function successCallback(data) {
    window.location.href = '/Tournaments/Index/';
}
function errorCallback(err) {
    window.location.href = '/Tournaments/Index/';
}