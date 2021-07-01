var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [
            { "data": "firstName", "width": "15%" },
            { "data": "lastName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "role", "width": "15%" },
            {
                "data": "isVerified",
                "render": function (data) {
                    if (data) {
                        return `<p style="color:Green">Verified</p>`;
                    }
                    else {
                        return `<p style="color:Red">Not Verified</P>`;
                    }
                },
                "width": "10%"
            },
            {
                "data": "verifiedStatus",
                "render": function (data) {
                    if (data != null) {
                        if (data == 'Approved') {
                            return `<p style="color:Green">Approved</p>`;
                        }
                        else {
                            return `<p style="color:Red">Rejected</P>`;
                        }
                    }
                    else {
                        return ``;
                    }
                },
                "width": "10%"
            },
            {
                "data":{
                    id: "id", lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        //user is currently locked
                        return `
                            <div class="text-center">
                                <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                    <i class="fas fa-lock-open"></i>  Unlock
                                </a>
                            </div>
                           `;
                    }
                    else {
                        return `
                            <div class="text-center">
                                <a href="/Admin/User/Verify/${data.id}" class="btn btn-primary" style="cursor:pointer">
                                                                    Verify
                                </a>
                                <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="fas fa-lock"></i>  Lock
                                </a>
                            </div>
                           `;
                    }

                }, "width": "25%"
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
            else {
                toastr.error(data.message);
            }
        }
    });

}