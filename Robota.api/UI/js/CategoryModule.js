var Category = {
    url: 'api/category',
    token: localStorage.getItem('token'),
    
    getAll: function (baseUrl, handler) {
        var that = this;
        $.ajax({
            url: baseUrl +  this.url,
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
    
    create: function (baseUrl, name, handler) {
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
            data: {name: name},
            success: function(data) {
                handler(data);
            }
        });
    },
    
    edit: function (baseUrl, id, name, handler) {
        var that = this;
        $.ajax({
            url: baseUrl + this.url + "/edit?id=" +id + "&name=" + name,
            method: 'put',
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
    
    createSelect: function(baseUrl, selector) {
        this.getAll(baseUrl, function(data) {
            var options = "";
        
            for(var i=0; i< data.length; i++) {
                options+= '<option value="'+ data[i].id +'">' + data[i].name + "</option>";
            }
            $(selector).html(options);
        });
    },
    
    buildTable: function(baseUrl, selector) {
        this.getAll(baseUrl, function(data) {
            var rows = "";
            for(var i=0; i<data.length; i++) {
                rows += "<tr><td>" + (i+1) + "</td><td>" + data[i].name + "</td><td class='editCategory' data-id='" + data[i].id + "'>Edit</td><td class='delCategory' data-id='" + data[i].id + "'>Delete</td></tr>";
            }
            $(selector).html(rows);
        });
    },
    badToken: function () {
        localStorage.removeItem("token");
        window.location.replace("auth.html");
    }
};
//export Category;