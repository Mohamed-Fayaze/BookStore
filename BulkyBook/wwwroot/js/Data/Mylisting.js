var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Customer/BusinessProfile/GetMylisting"
        },
        "columns": [
            {
                "data": "profilePhoto",
                "render": function (data) {
                    return `
                            <img id="imgpfl" src="${ data }" alt="" class="card-img-top rounded" style="width:100px;" />
                            `;
                   
                },"width": "15%"
            },
            { "data": "name", "width": "15%" },
            //{ "data": "dateOfRegistered", "width": "10%" },
            //{
            //    "data": "isAuthorizedCompany",
            //    "render": function (data) {
            //        if (data) {
            //            return `<input type="checkbox" disabled checked />`
            //        }
            //        else {
            //            return `<input type="checkbox" disabled/>`
            //        }
            //    },
            //    "width": "10%"
            //},
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
<a href="/Customer/AddressTables/Index?businessid=${data}" class="text-success" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> Address
<a href="/Customer/Home/DetailLive/${data}" class="text-success" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> View
                                </a>&nbsp;&nbsp;&nbsp;
                                <a href="/Customer/BusinessProfile/Upsert/${data}" class="text-success" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> Edit
                                </a>&nbsp;&nbsp;&nbsp;
                                <a onclick=Delete("/Admin/Company/Delete/${data}") class="text-danger" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "25%"
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