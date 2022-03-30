
    $(document).ready(function () {

        
        $(".menu-button").click(function () {

           
            var id1 = $(this).attr('id');
            var CouID = $('#CourseId').val();
         
            //CourseId
            //var start = $('#ct').val();
            //var start = $('#ct').text();
            //var dr = $('#dr').val();
            //alert(start);
            //var start = $('#start').text();
            //var ct = $('#ct').text();
            //var dr = $('#dr').val();
            //var mediaid = $('#mediaid').val();
            //$("#" + mediaid).parent().parent().parent().css("background-color", "white");
            //$("#" + mediaid).parent().parent().parent().children().children().children().css("color", "black");
            //if (dr == null || ct == "" || ct == null) {
            //    console.log("iff");
            //} else {
            //    if (ct == dr) {
            //        $("#" + mediaid).parent().children().children().text('check_circle');
            //        console.log("if");     
            //    } else if (ct == 0) {
            //        $("#" + mediaid).parent().children().children().text('play_circle_filled');
            //        console.log("elseif");
            //    } else {
            //        $("#" + mediaid).parent().children().children().text('pause_circle_filled');     
            //        console.log("else");
            //    }
            //}
           //$(this).parent().parent().parent().parent().children().css("background-color", "white");
           // var re = '<i class="material-icons text-muted pr-2">play_circle_filled</i>';
           // $(this).children().append(re);
         //var SecId = $('#SectionMediaId').val();
           

            $('#video-card').empty();
          
          
            $('.sidebar').empty();
            dd(CouID, id1);
            $.ajax({
                //base address/controller/Action
                url: '/Home/videoplayer',
                type: 'GET',
                data: {
                    //Passing Input parameter
                    cid: CouID,
                    sid: id1
                },
                success: function (result) {
                    //write something
               
                    $('#video-card').append(result);
                    $('#video-card').show();

                    $('html').animate({
                        scrollTop: $("body").offset().top
                    });

                   
                    //var id = $('#' + id1).parent().parent().parent().parent().attr('id');
                    //var start = $('#start').val();
                   //vd(player);           
                   // $(a).css("background-color", "yellow");
                    //$('DOCTYPE h').val = result;
                   // $('html').append("" + result);
                },
                error: function () {
                    alert(" ready error");
                }              
            });
           
        });
 });


function dd(CouID,id) {


    $.ajax({
        //base address/controller/Action
        url: '/Home/Sectons',
        type: 'GET',
        data: {
            //Passing Input parameter
            cid: CouID

        },
        success: function (result) {
            //write something
            $('.sidebar').append(result);
            $('.sidebar').show();
          
            var id2 = $('#' + id).parent().parent().parent().attr('id');

            $('#' + id2).collapse('show');

            $('#' + id).parent().parent().css("background-color", "#667a8a");


            $('#' + id).parent().parent().parent().children().children().children().css("color", "white");
        },
        error: function () {
            alert("dd dd error");
        }

    });
}



   





    



  








