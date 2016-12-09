(function () {

    var templates = {};

    function merge(template, obj) {
        if (!templates[template]) {
            templates[template] = $("#" + template).html();
        }
        var html = templates[template];
        return html.replace(/{{(\w+)}}/gi, function (m, name) {            
            return obj[name];
        });
    }

    $.post("/Person/AllPeople")
        .done(function (people) {
            var content = $("#content");
            people.forEach(function (person) {
                content.append(merge("tmpl", person));
            });
        })
        .fail(function () {
            console.log("failed!");
        });

})();