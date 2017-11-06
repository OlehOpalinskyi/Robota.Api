$(function () {
    var baseUrl = "http://localhost:58665/";
    var category = localStorage.getItem('categoryId');

    Persons.buildTable(baseUrl + "/api/persons/by-category/" + category, "#table");

    $(document).on('click', '.btn-danger', function () {
        var that = $(this);
        var id = that.data('id') * 1;
        Persons.delete(baseUrl, id, function () {
            that.closest('tr').remove();
        });
    });

    /*--------------------edit person----------------*/

    $(document).on('click', '.btn-primary', function () {
        var id = $(this).data('id') * 1;
        Persons.byId(baseUrl, id, function(data) {
            populate($('#person'), data);
            $('#editUser').attr('data-id', id);
        });
    });
    $('#editUser').click(function() {
        var id = $(this).data('id') * 1;
        var form = $('#person').serializeArray();
        var data = objectifyForm(form);
        data.categoryId = localStorage.getItem('categoryId');
        Persons.edit(baseUrl, id, data, function() {
            $('#person')[0].reset();
            $('#close').click();
            Persons.buildTable(baseUrl + "/api/persons/by-category/" + category, "#table");
        });
    });

    $('#btnFilter').click(function () {
        if ($('.min-price').val() !== "" && $('.max-price').val() !== "") {
            var form = $('#filter').serialize();
            var url = "api/persons/filtered?categoryId=" + category + "&" + form;
            console.log(url);
            Persons.buildTable(baseUrl + url, '#table');
        }
        else
            alert('input all rows');
    });

    $(".min-price, .max-price").keypress(function (e) {
        var charCode = (e.which) ? e.which : e.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
    });

    $('#myInput').keypress(function (e) {
        if (e.which == 13) {
            var name = $(this).val();
            Persons.buildTable(baseUrl + "/api/persons/by-name/" + category + '/' + name, "#table");
        }
    });

    $("#myInput").keyup(function (e) {
        if (e.keyCode == 27) {
            $(this).val("");
            Persons.buildTable(baseUrl + "/api/persons/by-category/" + category, "#table");
        }
    });
});

function populate(frm, data) {
    $.each(data, function (key, value) {
        var ctrl = $('[name=' + key + ']', frm);
        switch (ctrl.prop("type")) {
            case "radio": case "checkbox":
                ctrl.each(function () {
                    if ($(this).attr('value') == value) $(this).attr("checked", value);
                });
                break;
            default:
                ctrl.val(value);
        }
    });
}
function objectifyForm(formArray) {//serialize data function

    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]['name']] = formArray[i]['value'];
    }
    return returnArray;
}