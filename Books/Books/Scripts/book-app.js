(function () {

    var data = {
        books: [],
        modal: {
            adding: true,
            title: "Add Book"
        },
        book: {}
    };

    var methods = {
        showAddBook: function () {
            data.modal.adding = true;
            data.modal.title = "Add Book";
            data.book = {
                title: "",
                imgUrl: ""
            };
            $("#modalBook").modal("show");
        },
        add: function () {
            data.books.push(data.book);
            $("#modalBook").modal("hide");
        },
        showEditBook: function (book) {
            data.modal.adding = false;
            data.modal.title = "Edit " + book.title;
            data.book = book;
            $("#modalBook").modal("show");
        },
        edit: function () {
            $("#modalBook").modal("hide");
        }
    };

    var app = new Vue({
        el: "#book-app",
        data: data,
        methods: methods
    });

})();