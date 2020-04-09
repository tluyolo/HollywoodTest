var parsedSelectedTournament = $.parseJSON(selectedTournament);

$(function () {
    ko.applyBindings(modelDelete);        
});

var modelDelete = {
    //Delete
    TournamentID: ko.observable(parsedSelectedTournament.TournamentID),
    TournamentName: ko.observable(parsedSelectedTournament.TournamentName),

    deleteTournament: function () {
        try {
            $.ajax({
                url: '/Tournaments/Delete',
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
    //End delete here   
}

function successCallback(data) {
    window.location.href = '/Tournaments/Index/';
}
function errorCallback(err) {
    window.location.href = '/Tournaments/Index/';
}