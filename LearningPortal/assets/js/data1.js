
$(document).ready(function () {
    lg();
});


function lg() {

    var player = videojs(document.querySelector("video"), {
        //inactivityTimeout: 0 // HIDE OR NOTE CONTROL BAR


    });

    $(document).ready(function () {

      
        videojs('vemvo-player').on('ended', function () {

            var nextmediaid = $('#nextmediaid').val();
            
            if (nextmediaid == 0) {

            } else {
                setTimeout(function () {

                    var courseid = $('#CourseId').val();
                    var mediaid = $('#mediaid').val();
                    var nextmediaid = $('#nextmediaid').val();
                    videoget(courseid, nextmediaid, mediaid);
                }, 2000);
            }
            
           
        });

       

        var type = $('#type').val();
        var start = $('#start').val();
        var mediaid = $('#mediaid').val();
        var CouID = $('#CourseId').val();


        if (type == "video/mp4") {
            player.currentTime(start);
        }
        videojs('vemvo-player').on('play', function () {


            if (player.readyState() < 1) {
                // wait for loadedmetdata event
                player.one("readymetadata", Onready);
            }
            else {
                Onready();
            }
            function Onready() {
                setInterval(function () {


                    datasend(mediaid, player.currentTime().toString(), player.duration().toString(), CouID);
                }, 1000);
            }
        });
    });

    var Button = videojs.getComponent("Button");
    // Extend default
    var PrevButton = videojs.extend(Button, {
        //constructor: function(player, options) {
        constructor: function () {
            Button.apply(this, arguments);
            //this.addClass('vjs-chapters-button');

            /* FONT AWESOME ICON PREVIOUS NEXT */
            // this.addClass("icon-angle-left");
            // this.controlText("Previous");

            /* NEW VIDEOJS ICON PREV NEXT */
            this.addClass("vjs-icon-previous-item");
            this.controlText("Previous");

        },

        // constructor: function() {
        //   Button.apply(this, arguments);
        //   this.addClass('vjs-play-control vjs-control vjs-button vjs-paused');
        // },

        // createEl: function() {
        //   return Button.prototype.createEl('button', {
        //     //className: 'vjs-next-button vjs-control vjs-button',
        //     //innerHTML: 'Next >'
        //   });
        // },

        handleClick: function () {
            console.log("click");
            var courseid = $('#CourseId').val();

            var prevmediaid = $('#prevmediaid').val();
            var mediaid = $('#mediaid').val();
            //window.location.href = courseid.trim() + "?sid=" + prevmediaid.trim();

            videoget(courseid, prevmediaid, mediaid);


            //player.playlist.previous();

        }
    });


    /* ADD BUTTON */
    var Button = videojs.getComponent('Button');







    // Extend default
    var NextButton = videojs.extend(Button, {
        //constructor: function(player, options) {
        constructor: function () {
            Button.apply(this, arguments);
            //this.addClass('vjs-chapters-button');

            /* FONT AWESOME ICON PREVIOUS NEXT */
            // this.addClass("icon-angle-right");
            // this.controlText("Next");

            /* NEW VIDEOJS ICON PREV NEXT */
            this.addClass("vjs-icon-next-item");
            this.controlText("Next");
        },

        handleClick: function () {





            var courseid = $('#CourseId').val();
            var mediaid = $('#mediaid').val();
            var nextmediaid = $('#nextmediaid').val();
            console.log("click");

            //window.location.href = courseid.trim() + "?sid=" + nextmediaid.trim();

            videoget(courseid, nextmediaid, mediaid);
            // player.playlist.next();
            //newVideo(courseid, nextmediaid);

        }
    });



    function videoget(CouID, id1 , id2) {


        $(document).ready(function () {
         

            //var start = $('#start').text();
            //var ct = $('#ct').text();
            //var dr = $('#dr').val();
            //var mediaid = $('#mediaid').val();

            //$("#" + id2).parent().parent().parent().css("background-color", "white");
            //$("#" + id2).parent().parent().parent().children().children().children().css("color", "black");
            //if (dr == null || ct == "" || ct == null) {

                
            //    console.log("iff");
            //} else {
            //    if (start == dr) {
            //        $("#" + id2).parent().children().children().text('check_circle');
            //        console.log("if");

            //    } else if (start == 0) {
            //        $("#" + id2).parent().children().children().text('play_circle_filled');
            //        console.log("elseif");
            //    } else {
            //        $("#" + id2).parent().children().children().text('pause_circle_filled');
                  
            //        console.log("else");
            //    }

            //}



           
           
         

            //$('#' + id1).parent().parent().parent().css("background-color", "#667a8a");




            //$('#' + id1).parent().parent().parent().children().children().children().css("color", "white");

            //var id = $('#' + id1).parent().parent().parent().parent().attr('id');
          

            //$("#" + id).collapse('show');
          
            var CouID = $('#CourseId').val();
            $('#video-card').empty();


            

            $.ajax({
               
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
                    $('.sidebar').empty();
                    dd(CouID, id1);

                    
                    $('html, body').animate({
                        scrollTop: $("body").offset().top
                    }, 1000);
                 

                },
                error: function () {
                    alert("get error");
                }
            });

        });
    }


    //}


    function datasend(id, currentime, tduration,coid) {

        $(document).ready(function () {
           
            val1 = id;
            check = parseInt(tduration);
            val2 = parseInt(currentime);
           
            var a22 = val2;
            $('#start').text(a22);
            $('#ct').text(a22);
           
            if ((check) == (val2 + 1)) {
                val2 = check;
            } else {

                val2 = parseInt(currentime);
            }
            $.ajax({
                type: "POST",
                url: '/Home/UpdateUserMedia',
                data: { number1: val1, number2: val2, cid: coid },

                success: function (msg) {

                },
                error: function (req, status, error) {
                    console.log(error.toString());
                }
            });
        });

    }

    // Register the new component
    videojs.registerComponent("NextButton", NextButton);
    videojs.registerComponent("PrevButton", PrevButton);
    //player.getChild('controlBar').addChild('SharingButton', {});
    player.getChild("controlBar").addChild("PrevButton", {}, 0);
    player.getChild("controlBar").addChild("NextButton", {}, 2);



    function dd(CouID, id) {

      

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
                alert(" ddd1 error");
            }

        });
    }



}
