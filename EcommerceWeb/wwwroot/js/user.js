var dataTable;
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getAll' },
        "columns": [
            { data: 'name', "width": "5%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "5%" },
            { data: 'role', "width": "5%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {

                        return `<div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-primary mx-2">
                                <i class="bi bi-lock"></i> Unlock
                            </a>
                             <a class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i>Permission
                            </a>
                        </div>
                        `
                    } else {
                        return `<div class="text-center">
                            <a onclick=LockUnlock('${data.id}')  class="btn btn-danger" width:100px>
                                <i class="bi bi-unlock"></i> Lock
                            </a>
                             <a class="btn btn-primary" width:100px>
                                <i class="bi bi-pencil-square"></i>Permission
                            </a>
                        </div>
                        `

                    }

                } ,
                "width": "5%"
            }

        ]
    });

}


function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}
