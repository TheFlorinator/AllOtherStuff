(function () {

    function loadAllPeople() {
        $.getJSON("/api/Persons")
            .done(function (people) {
                var tblBody = $("#tblBody");
                tblBody.empty();
                people.forEach(function (person) {
                    var rowHTML = "<tr>"
                        + "<td>" + person.FirstName + "</td>"
                        + "<td>" + person.LastName + "</td>"
                        + "<td>" + person.Country + "</td>"
                    + "</tr>";
                    tblBody.append(rowHTML);
                });
            })
            .fail(function () {
                console.log("failed!");
            });
    }

    $("#frm").submit(function (evt) {

        var data = {};
        evt.preventDefault();
        $("#modalEditPerson").modal('hide');

        $(this).serializeArray().forEach(function (pair) {
            data[pair.name] = pair.value;
        });

        $.post("/api/Persons", data)
            .done(function () {
                console.log("saved!");

                loadAllPeople();
            }).fail(function () {
                console.log("failed!");
            });

        return false;
    });

    loadAllPeople();

})();