function Save() {
    var url = "http://localhost:5164/Expense/Create";
    var objectProduct = {};
    objectProduct.ExpenseDate = $('#ExpenseDate').val();
    objectProduct.ExpenseGIvenTo = $('#ExpenseGIvenTo').val();
    objectProduct.ExpenseAmount = $('#ExpenseAmount').val();
    if (objectProduct) {
        $.ajax({
            url: url,
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(objectProduct),
            type: "POST",
            success: function (data, textStatus, xhr) {
                if (xhr.status == 200) {
                    alert("Saved Successfully");
                    location.href = "http://localhost:5135/expense/index";

                }
            },
            Error: function (msg) {
                alert(msg);
            }
        });
    }
}

function Getdata() {
    var url = "http://localhost:5164/Expense";

    $.ajax({
        url: url,
        type: "Get",
        success: function (data, textStatus, xhr) {
            console.log(data);
            if (data) {
                var row = '';
                for (var i = 0; i < data.length; i++) {
                    row = row
                        + "<tr>"
                        + "<td width='20%'>" + data[i].expenseDate + "</td>"
                        + "<td width='20%'>" + data[i].expenseGIvenTo + "</td>"
                        + "<td width='20%'>" + data[i].expenseAmount + "</td>"
                        + "<td width='30%'>"
                        + "<div class='w-100 btn-group' role='group'>"
                        + "<a href='http://localhost:5135/Expense/GetExpenseDetailsForUpdate?expenseId=" + data[i].expenseId + "' class='btn btn-primary mx-1'>Update</a>"
                        + "<a class='btn btn-danger mx-1' onclick='Delete(" + data[i].expenseId + ")'>Delete</a>"
                        + "</div>"
                        + "</td>"
                        + "</tr>"
                }
                if (row != '') {
                    $('#tblproductid').append(row);

                }
            }
        },
        error: function (msg) {
            alert(msg);
        }
    });
}

function getExpenseByID(id) {

    var url = "http://localhost:5164/Expense/GetExpenseByID?id=" + id + "";

    $.ajax({
        url: url,
        contentType: "application/json;charset=utf-8",
        type: "Get",
        success: function (data, textStatus, xhr) {
            if (xhr.status == 200) {

                document.getElementById("ExpenseDate").valueAsDate = new Date(data.expenseDate)
                $('#ExpenseGIvenTo').val(data.expenseGIvenTo);
                $('#ExpenseAmount').val(data.expenseAmount);
            }
        },
        Error: function (msg) {
            alert(msg);
        }
    });
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function Update() {

    var id = getParameterByName("expenseId");

    var url = "http://localhost:5164/Expense/Update";
    var objectProduct = {};

    objectProduct.ExpenseId = id;
    objectProduct.ExpenseDate = $('#ExpenseDate').val();
    objectProduct.ExpenseGIvenTo = $('#ExpenseGIvenTo').val();
    objectProduct.ExpenseAmount = $('#ExpenseAmount').val();
    if (objectProduct) {
        $.ajax({
            url: url,
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(objectProduct),
            type: "POST",
            success: function (data, textStatus, xhr) {
                if (xhr.status == 200) {
                    alert("Saved Successfully");
                    location.href = "http://localhost:5135/expense/index";
                }
            },
            Error: function (msg) {
                alert(msg);
            }
        });
    }



}

function Delete(id) {

    var url = "http://localhost:5164/Expense/Delete?ExpenseId=" + id + "";

    $.ajax({
        url: url,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        type: "Delete",
        success: function (data, textStatus, xhr) {
            if (xhr.status == 200) {
                alert("Deleted Successfully");
                location.href = "http://localhost:5135/expense/index";

            }
        },
        Error: function (msg) {
            alert(msg);
        }
    });
}
