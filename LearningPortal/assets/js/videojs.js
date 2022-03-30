// https://github.com/brightcove/videojs-playlist/blob/master/docs/api.md
// http://docs.videojs.com/docs/guides/plugins.html
// https://github.com/brightcove/videojs-playlist
// https://github.com/manelpb/videojs-playlist-thumbs // do not work



    var player = videojs(document.querySelector("video"), {
        //inactivityTimeout: 0 // HIDE OR NOTE CONTROL BAR


    });
   


$(document).ready(function () {

    var type = $('#type').val();
    var start = $('#start').val();
    var mediaid = $('#mediaid').val();
    


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

                
              datasend(mediaid, player.currentTime().toString(), player.duration().toString());
            },1000);
        }
    });
});
//player.playlist(videoList);
function initialize() {


console.log("Dwa");
}
// try {
//   // try on ios
//   player.volume(1);
//   // player.play();
// } catch (e) {}
//player.playlist(videoList;

//player.playlist(videoList);
/*
document.querySelector(".previous").addEventListener("click", function() {
  player.playlist.previous();
});
document.querySelector(".next").addEventListener("click", function() {
  player.playlist.next();
});
document.querySelector(".jump").addEventListener("click", function() {
  player.playlist.currentItem(2); // play third
  player.play();
});
*/
//player.playlist.autoadvance(0); // play all


// Array.prototype.forEach.call(
//   document.querySelectorAll("[name=autoadvance]"),
//   function(el) {
//     el.addEventListener("click", function() {
//       var value = document.querySelector("[name=autoadvance]:checked").value;
//       //alert(value);
//       player.playlist.autoadvance(JSON.parse(value));
//     });
//   }
// );
/* ADD PREVIOUS */
var Button = videojs.getComponent("Button");
// Extend default
var PrevButton = videojs.extend(Button, {
  //constructor: function(player, options) {
  constructor: function() {
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

  handleClick: function() {
    console.log("click");
      var courseid = $('#CourseId').val();

      var prevmediaid = $('#prevmediaid').val();

     
   //window.location.href = courseid.trim() + "?sid=" + prevmediaid.trim();

      videoget(courseid, prevmediaid);
     
 
    //player.playlist.previous();
  
  }
});




function newVideo(id, sid) {

    $(document).ready(function () {
        val1 = id;
        val2 = sid;
        // console.log(val + " " + val1);



        $.ajax({
            type: "GET",
            url: '/Home/StudentCourse',
            data: { number1: val1, number2: val2 },

            success: function (msg) {
                alert("dwa");
            },
            error: function (req, status, error) {
                console.log(error.toString());
            }
        });

    });
}




function datasend(id, currentime ,tduration) {

    $(document).ready(function () {
  
        val1 = id;     
        check = parseInt(tduration);
        val2 = parseInt(currentime);
       
        if ((check) == (val2+1)) {
            val2 = check;
        } else {
         
            val2 = parseInt(currentime);
        }
        $.ajax({
            type: "POST",
            url: '/Home/UpdateUserMedia',
            data: { number1: val1, number2: val2 },

            success: function (msg) {
                
            },
            error: function (req, status, error) {
                console.log(error.toString());
            }
        });
    });
   
}





function formatTime_hourformat(time1) {
   
  var time=parseInt(time1);
  //var sec=time;
  //alert(sec);

  var hour = Math.floor(time / 3600),
  minutes = time - hour * 3600;
  minutes = Math.floor(minutes / 60),
  seconds = Math.floor(time - minutes * 60 - hour * 3600);



// var    minutes =Math.floor(minutes/60),
//  seconds = time - minutes * 60;

seconds = seconds < 10 ? '0' + seconds : seconds;

return hour + ":" + minutes + ":" + seconds;
  



  // var    minutes =Math.floor(minutes/60),
  //  seconds = time - minutes * 60;

 
  
  
 
}





/* ADD BUTTON */
var Button = videojs.getComponent('Button');







// Extend default
var NextButton = videojs.extend(Button, {
  //constructor: function(player, options) {
  constructor: function() {
    Button.apply(this, arguments);
    //this.addClass('vjs-chapters-button');

    /* FONT AWESOME ICON PREVIOUS NEXT */
    // this.addClass("icon-angle-right");
    // this.controlText("Next");
    
    /* NEW VIDEOJS ICON PREV NEXT */
    this.addClass("vjs-icon-next-item");
    this.controlText("Next");
  },

  handleClick: function() {
   
    
   


      var courseid = $('#CourseId').val();
         
      var nextmediaid = $('#nextmediaid').val();
      //console.log(nextmediaid);

     //window.location.href = courseid.trim() + "?sid=" + nextmediaid.trim();

      videoget(courseid, nextmediaid);
    // player.playlist.next();
      //newVideo(courseid, nextmediaid);
  
  }
});



function videoget(CouID ,id1) {


    $(document).ready(function () {


        $('#'+id1).parent().parent().parent().parent().children().css("background-color", "white");
        $('#'+id1).parent().parent().parent().css("background-color", "yellow");
        //$(this).parent().parent().parent().parent().children().css("background-color", "white");
       //$(this).parent().parent().parent().css("background-color", "yellow");
            //var id1 = $(this).attr('id');

        //$('#'+id1).parent().parent().parent().css("background-color", "yellow");
            //$("#video-card").hide();


           // var CouID = $('#CourseId').val();
            //var SecId = $('#SectionMediaId').val();

            $('#video-card').empty();


            //$("#video-card").show();

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
                    // $(a).css("background-color", "yellow");
                    //$('DOCTYPE h').val = result;
                    // $('html').append("" + result);
                },
                error: function () {
                    alert("error");
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
//player.controlBar.addChild('SharingButton', {}, 6);

//var MyButton = player.controlBar.addChild(new MyButtonComponent(), {}, 6);

//const ControlBar = videojs.getComponent('ControlBar');
//ControlBar.prototype.options_.children.splice(ControlBar.prototype.options_.children.length - 1, 0, 'SharingButton');

// Register the new component
//videojs.registerComponent('SharingButton', SharingButton);
//player.getChild('controlBar').addChild('SharingButton', {});




