var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Customer/BusinessProfile/GetFavourite"
        },
        "columns": [
            {
                "data": "company.profilePhoto",
                "render": function (data) {
                    return `
                        <img src="${data}" class="card-img-top rounded img-fluid" style="width:100px;" />
                            `;
                },"width": "15%"
            },
            { "data": "company.name", "width": "15%" },
            //{ "data": "company.dateOfRegistered", "width": "10%" },
            {
                "data": "company.id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Customer/Home/DetailLive/${data}" class="text-success" style="cursor:pointer">
                                     View
                                </a>&nbsp;&nbsp;&nbsp;
                                 <a onclick=Delete("/Customer/BusinessProfile/RemoveFavourite/${data}") class="text-danger" style="cursor:pointer">
                                     Remove
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
        title: "Are you sure you want to Remove?",
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


