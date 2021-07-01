﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Promotion/GetAll"
        },
        "columns": [
            { "data": "business.name", "width": "10%" },
            { "data": "oldPrice", "width": "10%" },
            { "data": "offerPrice", "width": "10%" },
            { "data": "discount", "width": "10%" },
            { "data": "startDate", "width": "10%" },
            { "data": "endDate", "width": "10%" },
            { "data": "promoDescription", "width": "10%" },
            //{ "data": "uploadFile", "width": "10%" },

            {
                "data": "uploadFile",
                "render": function (data) {
                    return `
                            <img src="${data}" alt="" class="card-img-top rounded" style="width:100px;" />
                            `;

                }, "width": "15%"
            },



            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Promotion/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/Promotion/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
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