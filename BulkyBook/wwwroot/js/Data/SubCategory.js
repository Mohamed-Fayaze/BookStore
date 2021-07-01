var dataTable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        "ajax": {
            "url": "/Admin/SubCategory/GetAll"
        },
        "columns": [
             {"data":"PrimaryCategory.CategoryName","width":"30%"},

            { "data": "secondaryName", "width": "30%" },

            {
                "data": "subCategoryIcon",
                "render": function (data) {
                    return `
                           <img src = "${data}" width = "50%" style = "border-radius:5px; border:1px solid #bbb9b9" />
                             `;
                }, "width": "10%"
            },

            {
                "data": "subCategoryImage",
                "render": function (data) {
                    return `
                           <img src = "${data}" width = "50%" style = "border-radius:5px; border:1px solid #bbb9b9" />
                             `;
                }, "width": "20%"
            },

            {
                "data": "secondaryId",
                "render": function (data) {
                    return `

                           <a href="/Admin/SubCategory/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                          <i class="fas fa-edit"></i> 
                         </a>
                           
                        <a onclick=Delete("/Admin/SubCategory/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                        <i class="fas fa-trash-alt"></i>  
                          </a>


                         `;
                }, "width": "40%"
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