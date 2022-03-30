var player,
    time_update_interval = 0;

function onYouTubeIframeAPIReady() {
    /*player = new YT.Player('player', {
      
        events: {
            onchange: initialize
        }
    });*/

    player = new YT.Player('player', {


        events: { 'onReady': initialize }
    });




}




function initialize() {


    var a = document.getElementById('currenttime1').value;

    player.seekTo(parseInt(a));

    $(document).ready(function () {

        var a1 = $(".html5-video-player").contents();
        console.log(a1);

    });
    updateTimerDisplay();

    // Clear any old interval.
    clearInterval(time_update_interval);
    //var val = document.getElementById('Id').value;

    // Start interval to update elapsed time display and
    // the elapsed part of the progress bar every second.
    time_update_interval = setInterval(function () {
        updateTimerDisplay();
        // document.getElementById(val).submit();
        //console.log(document.getElementById("Id").value);
        // console.log(document.getElementById("currenttime").innerText);

        datasend(document.getElementById("SectionMediaId").value, document.getElementById("currenttime").innerText);

    }, 1000);



}

function datasend(id, currentime) {


    $(document).ready(function () {


        val1 = id;
        val2 = currentime;

        $.ajax({
            type: "POST",
            url: '/Home/UpdateUserMedia',
            data: { number1: val1, number2: val2 },

            success: function (msg) {
                console.log(msg);
            },
            error: function (req, status, error) {
                console.log(error.toString());
            }
        });
    });
    /*
    $.ajax({
        
        type: 'POST',
        url: '@Url.Action("UpdateUserMedia","Home")',
        data: '{ "id":' + id + ', "currenttime":' + currentime + ' }',
        success: function (result) {
            alert('Yay! It worked!');
        },
        error: function (result) {
            alert('Oh no :(');
        }
    });*/
}

// This function is called by initialize()
function updateTimerDisplay() {
    // Update current time text display.
    $('#currenttime').text(formatTime(player.getCurrentTime()));
    

    //$('#totalDuration').text(formatTime_hourformat(player.getDuration()));
}














// Helper Functions

function formatTime(time) {
    time = Math.round(time);


    return time;
}


function formatTime_hourformat(time) {



    var hour = Math.floor(time / 3600),
        minutes = time - hour * 3600;
    minutes = Math.floor(minutes / 60),
        seconds = Math.floor(time - minutes* 60 - hour *3600);

    // var    minutes =Math.floor(minutes/60),
    //  seconds = time - minutes * 60;

    seconds = seconds < 10 ? '0' + seconds : seconds;

    return hour + ":" + minutes + ":" + seconds;
}

