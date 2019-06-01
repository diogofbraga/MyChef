var beginning = Date.now();
var end = Date.now();

function starttime(){
    var t = Date.now() - beginning;
    var seconds = Math.floor( (t/1000) % 60 );
    var minutes = Math.floor( (t/1000/60) % 60 );
    var hours = Math.floor((t / (1000 * 60 * 60)) % 24);

    end = seconds;

    document.getElementById('h').innerHTML=hours;
    document.getElementById('m').innerHTML=minutes;
    document.getElementById('s').innerHTML=seconds;

    var q = setTimeout(starttime, 500);

}


window.onload = starttime;