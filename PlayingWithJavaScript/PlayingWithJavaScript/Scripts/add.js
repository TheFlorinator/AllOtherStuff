(function () {

    $("#frm").submit(function (evt) {

        var data = {};
        evt.preventDefault();

        $(this).serializeArray().forEach(function (pair) {
            data[pair.name] = pair.value;
        });

        $.post("/api/Persons", data)
            .done(function () {
                console.log("saved!");
            }).fail(function () {
                console.log("failed!");
            });

        return false;
    });

})();