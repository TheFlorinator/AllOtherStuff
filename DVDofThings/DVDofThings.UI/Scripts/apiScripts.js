
$(document).ready(function () {
    var urls = {
        getDvds: "/api/Home/GetDvds",
    };

    var $dvdTable = $('#dvdAccordian');

    $.getJSON(urls.getDvd)
        .then(function (dvds) {
            dvds.forEach(function (dvd) {
                var row = $("#accordian").clone();
                row.find('.headerBiz').text(dvd.Name);
                row.click(function () {
                    console.log('Hello');
                });
                dvdTable.append(row);
                row.show();
                })
            })
        })






