//import './CategoryModule' from 'js';
$(function() {
   var baseUrl = "http://localhost:58665/"; 
    
  // Category.createSelect(baseUrl, "#category");// create select
   Category.getAll(baseUrl, function (data) {
       var divs = "";
       var options = "";
       for (var i = 0; i < data.length; i++) {
           divs += '<div class="col-md-3 col-xs-6 myCategory" data-id="' + data[i].id + '">' + data[i].name + '</div>';
           options += '<option value="' + data[i].id + '">' + data[i].name + "</option>";
       }
       $('#categories').html(divs);
       $('#category').html(options);
   });
    //Persons.buildTable(baseUrl + "api/persons", "#table");// build table persons
    //Category.buildTable(baseUrl, "#categoryTable");// build table category
    
    /*-----------Add Category--------------------------*/
   $('#addCategory').click(function () {
       var name = $('#categoryName');
       if (name.val() !== "") {
           Category.create(baseUrl, name.val(), function (data) {
               name.val("");
               div = '<div class="col-md-3 col-xs-6 myCategory" data-id="' + data.id + '">' + data.name + '</div>';
               option = '<option value="' + data.id + '">' + data.name + "</option>";
               $('#categories').append(div);
               $('#category').append(option);
           });
       }
       else
           alert('input name pls');
   });

   $(document).on('click', '.myCategory', function () {
       var id = $(this).data('id') * 1;
       localStorage.setItem('categoryId', id);
       localStorage.setItem('categoryName', $(this).text());
       window.location.replace("category.html");
   });

   $('#person input[name="fullName"]').blur(function () {
       var that = $(this);
       if (that.val().length < 5) {
           that.css('border-color', 'red');
           that.addClass('incorrect')
       }  
       else {
           that.css('border-color', 'green');
           that.removeClass('incorrect');
       }
           
   });

   $('#person input[name="email"]').blur(function () {
       var that = $(this);
       if (validateEmail(that.val()) == false) {
           that.css('border-color', 'red');
           that.addClass('incorrect')
       }
       else {
           that.css('border-color', 'green');
           that.removeClass('incorrect');
       }
   });

   $("#phone, #age").keypress(function (e) {
       var charCode = (e.which) ? e.which : e.keyCode;
       if (charCode > 31 && (charCode < 48 || charCode > 57)) {
           return false;
       }
   });

    ///*------------Edit Category -------------*/
    //$(document).on('click', '.editCategory', function() {
    //    var id = $(this).data('id') * 1;
    //    Category.byId(baseUrl, id, function(data) {
    //        $('#editName').val(data.name);
    //        $('#editCategory').attr('data-id', data.id);
    //    });
    //});
    //$('#editCategory').click(function() {
    //    var newName = $('#editName');
    //    var id = $(this).data('id') * 1;
    //    Category.edit(baseUrl, id, newName.val(), function(data) {
    //        Category.buildTable(baseUrl, "#categoryTable");
    //        newName.val("");
    //    });
    //});
    
    ///*--------------delete category------------*/
    //$(document).on('click', '.delCategory', function() {
    //    var that = $(this);
    //    var id = that.data('id') * 1;
    //    Category.delete(baseUrl, id, function() {
    //        that.closest("tr").remove();
    //    });
    //});
    
    ///*-------------create person-----------------*/
   $('#addUser').click(function () {
       if (checkForm($('#person')) == true && $('#person .incorrect').length == 0) {
           var form = $('#person').serializeArray();
           var data = objectifyForm(form);
           Persons.create(baseUrl, data, function (data) {
               $('#person')[0].reset();
               alert("Person added");
           });
       }
       else {
           alert('Incorrect data');
       }
    });
    
    ///*--------------------edit person----------------*/
    
    //$(document).on('click', '.editUser', function() {
    //    var id = $(this).data('id') * 1;
    //    Persons.byId(baseUrl, id, function(data) {
    //        populate($('#person'), data);
    //        $('#editUser').attr('data-id', id);
    //    });
    //});
    //$('#editUser').click(function() {
    //    var id = $(this).data('id') * 1;
    //    var form = $('#person').serializeArray();
    //    var data = objectifyForm(form);
    //    Persons.edit(baseUrl, id, data, function() {
    //        $('#person')[0].reset();
    //        Persons.buildTable(baseUrl + "api/persons", "#table");
    //    });
    //});
    
    ///*--------------------Search-------------------*/
    //$('#search').click(function() {
    //    var name = $('#name');
    //    var url = baseUrl + "api/persons/by-name/" + name.val();
    //    Persons.buildTable(url, "#table");
    //    name.val("");
    //});
});

function ShowData(data) {
    console.log(data);
}

function objectifyForm(formArray) {//serialize data function

  var returnArray = {};
  for (var i = 0; i < formArray.length; i++){
    returnArray[formArray[i]['name']] = formArray[i]['value'];
  }
  return returnArray;
}
function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}
function checkForm(form) {
    var arr = form.serializeArray();
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].value == "")
            return false;
    }
    return true;
}


