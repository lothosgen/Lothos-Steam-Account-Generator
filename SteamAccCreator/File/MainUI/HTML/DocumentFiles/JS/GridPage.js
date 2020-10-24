function buttonHandler_generate(){
    if(document.getElementById("btn_generate").getAttribute("name") === "false"){ 
        document.getElementById("btn_generate").setAttribute("name", "true");   
    } 
} 
function chkbuttonClick(id) {   
    if (document.getElementById(id).getAttribute("name") === "false")
    {   
        document.getElementById(id).style.background = "#c6900f";
        document.getElementById(id).setAttribute("name", "true");
    }   
    else   
    {   
        document.getElementById(id).style.background = "#202020";
        document.getElementById(id).setAttribute("name", "false");
    }   
}  
function onLOAD() {   
    alert("hi"); 
}   