var Persons = {
    url: "api/persons",
    token: localStorage.getItem('token'),
    
    Get: function (url, handler) {
        var that = this;
        $.ajax({
            url: url,
            method: 'get',
            headers: {
                Authorization: this.token
            },
            error: function (jqXHR, textStatus, errorThrown) {
                that.badToken();
            },
            success: function(data) {
                handler(data);
            }
        });
    },
    
    byId: function (baseUrl, id, handler) {
        var that = this;
        $.ajax({
            url: baseUrl + this.url + "/" + id,
            method: 'get',
            headers: {
                Authorization: this.token
            },
            error: function (jqXHR, textStatus, errorThrown) {
                that.badToken();
            },
            success: function(data) {
                handler(data);
            }
        });
    },
    
    create: function (baseUrl, obj, handler) {
        var that = this;
        $.ajax({
            url: baseUrl + this.url + "/create",
            method: 'post',
            headers: {
                Authorization: this.token
            },
            error: function (jqXHR, textStatus, errorThrown) {
                that.badToken();
            },
            data: obj,
            success: function(data) {
                handler(data);
            }
        });
    },
    
    edit: function (baseUrl, id, obj, handler) {
        var that = this;
        $.ajax({
            url: baseUrl + this.url + "/edit/" +id,
            method: 'put',
            headers: {
                Authorization: this.token
            },
            error: function (jqXHR, textStatus, errorThrown) {
                that.badToken();
            },
            data: obj,
            success: function(data) {
                handler(data);
            }
        });
    },
    
    delete: function (baseUrl, id, handler) {
        var that = this;
        $.ajax({
            url: baseUrl + this.url + "/remove/" + id,
            method: 'delete',
            headers: {
                Authorization: this.token
            },
            error: function (jqXHR, textStatus, errorThrown) {
                that.badToken();
            },
            success: function(data) {
                handler(data)
            }
        });
    },
    
    buildTable: function(url, selector) {
        this.Get(url, function(data) {
            var rows = "";
            for (var i = 0; i < data.length; i++) {
                var sex = (data[i].sex == 1) ? "Male" : "Female";
                rows += "<tr><td>" + (i + 1) + "</td><td>" + data[i].fullName + "</td><td>" + data[i].address + "</td><td>" + data[i].phoneNumber +
                    "</td><td>" + data[i].email + "</td><td>" + sex + "</td><td>" + data[i].age + '</td><td><button class="btn btn-primary btn-xs" data-toggle="modal" data-target="#edit" data-id="' + data[i].id +
                    '"><span class="glyphicon glyphicon-pencil"></span></button></td><td><button class="btn btn-danger btn-xs" data-id="'+data[i].id+'"><span class="glyphicon glyphicon-trash"></span></button></td></tr>';
            }
            $(selector).html(rows);
            $('#count').text("Count of people: " + data.length);
            $('#title').text(localStorage.getItem('categoryName'));
        });
    },

    badToken: function () {
        localStorage.removeItem("token");
        window.location.replace("auth.html");
    }
}