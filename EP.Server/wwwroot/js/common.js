
function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}

window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Success', { timeOut: 5000 })
    }

    if (type === "error") {
        toastr.error(message, 'Error', { timeOut: 5000 })
    }
}

function InitTable() {
    $("#mytable1").DataTable();
}

function LoadTable(data) {
    $("#mytable1").DataTable({
        data: data,
        columns: [
            { 'data': 'name' },
            { 'data':  'remarks' },
            {
                'data': 'addedDateTime',
                'render': function (jsonDate) {
                    var dt = new Date(jsonDate);
                    return dt.getDate() + "-" + dt.getMonth() + "-" + dt.getFullYear() + " " + dt.getHours() + ":"
                        + dt.getMinutes() + ":" + dt.getSeconds();
                }
            },
        ]
    });
}