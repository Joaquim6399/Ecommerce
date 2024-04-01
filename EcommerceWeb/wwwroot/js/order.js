
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getAll' },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "5%" },
            { data: 'applicationUser.phoneNumber', "width": "5%" },
            { data: 'applicationUser.email', "width": "15%" },
            { data: 'orderStatus', "width": "5%" },
            { data: 'orderTotal', "width": "5%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group" >
                        <a href="/admin/order/details?OrderId=${data}" class="btn btn-primary mx-2">Edit</a>
                    </div>
                    `
                } ,
                "width": "5%"
            }

        ]
    });

}
