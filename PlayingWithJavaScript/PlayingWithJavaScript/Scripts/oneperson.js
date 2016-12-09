(function () {

    $("#btn").click(function () {
        
        var id = $("#PersonId").val();
        if(isNaN(parseInt(id, 10))){
            return;
        }

        var promise = $.getJSON("/api/Persons/" + id);

        promise.done(function (person) {
            $("#spnFirstName").text(person.FirstName);
            $("#spnLastName").text(person.LastName);
            $("#spnCountry").text(person.Country);
            $("#pnlPerson").removeClass("hidden");
        }).fail(function () {
            console.log("failed!");
            $("#pnlPerson").addClass("hidden");
        });
            
    })

})();