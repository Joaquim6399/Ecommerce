
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getAll' },
        "columns": [
            { data: 'name', "width": "5%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "5%" },
            { data: 'city', "width": "5%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group" >
                        <a href="/customer/order/details?OrderId=${data}" class="btn btn-primary mx-2">Manage</a>
                    </div>
                    `
                } ,
                "width": "5%"
            }

        ]
    });

}

