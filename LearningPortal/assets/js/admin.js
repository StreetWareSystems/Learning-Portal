
$(document).ready(function () {
    
    var categoryId = $("#CategoryId").val();
    var subcategoryId = $("#SubCategoryId").val();
    var search = $("#searchText").val();
    var checkft = $("#CheckFt").is(":checked");

    //console.log(categoryId + " " + subcategoryId + search + checkft)

    $(".courseList").load("/Admin/CourseList", { catid: categoryId, subcatid: subcategoryId, tag: search, check: checkft });
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }
    $(".addimg").on('change', function () {
        var _URL = window.URL || window.webkitURL;
        var file = this.files[0],//get file   
            imgExt = file.name.replace(/^.*\./, ''),//get extension
            imgheight = 0,
            imgwidth = 0;
       
        var img = new Image();
        img.src = _URL.createObjectURL(file);
        img.onload = function () {
            imgheight = img.height;
            imgwidth = img.width;
           
                if ((img.width === 256 && img.height === 256) && (imgExt == "png" || imgExt == "jpg")) {
                    $("#upbtn").prop('disabled', false);
                    $(".addimg").siblings().addClass("text-muted");
                    $(".addimg").siblings().removeClass("text-danger");
                }
                else {
                    $(".addimg").siblings().removeClass("text-muted");
                    $(".addimg").siblings().addClass("text-danger");

            }

        }
    });
   
    //$("#CategoryId").change(function () {
    //    var categoryId = $(this).val();

    //    $.ajax({
    //        type: "post",
    //        url: "/Admin/GetSubCategoriesList?CategoryId=" + categoryId,
    //        contentType: "html",
    //        success: function (response) {
               
    //            $("#SubCategoryId").empty();
                
    //            $("#SubCategoryId").append(response);
    //        },
    //        error: function () {
    //            alert(error);
    //        }
    //    })

    //});
    $("#check").click(function () {
        var categoryId = $("#CategoryId").val();
        var subcategoryId = $("#SubCategoryId").val();
        var search = $("#searchText").val();
        var checkft = $("#CheckFt").is(":checked");
        $(".courseList").load("/Admin/CourseList", { catid: categoryId, subcatid: subcategoryId, tag: search, check: checkft });
    })

 
})