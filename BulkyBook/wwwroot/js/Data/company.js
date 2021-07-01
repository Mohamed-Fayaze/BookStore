var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            {
                "data": "profilePhoto",
                "render": function (data) {
                    if (data != "") {
                        return `
                            <img id="imgpfl" src="${data}" class="card-img-top rounded" style="width:100px;" />
                            `;
                    }
                    else {
                        return ``;
                    }
                }, "width": "15%"
            },
            { "data": "name", "width": "15%" },
            {
                "data": "createdOn",
                "render": function (data) {
                    var date = new Date(data);
                    return `
                            ${date.getDate()}/${date.getMonth()}/${date.getFullYear()}
                            `;
                },
                "width": "10%"
            },

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
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Company/Verify/${data}" class="btn btn-primary" style="cursor:pointer">
                                    Verify
                                </a>
                                <!--<a onclick=Delete("/Admin/Company/Delete/${data}") class="text-danger" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a> -->
                            </div>
                           `;
                }, "width": "10%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
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
    });
}