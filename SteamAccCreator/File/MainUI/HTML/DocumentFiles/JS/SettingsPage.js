function buttonHandler_generate() {  
    if (document.getElementById("btn_generate").getAttribute("name") === "false") {   
        document.getElementById("btn_generate").setAttribute("name", "true"); 
    } 
}   
function buttonHandler_add() {  
    if (document.getElementById("btn_add").getAttribute("name") === "false") {   
        document.getElementById("btn_add").setAttribute("name", "true"); 
    }   
} 
function CBHandler_email(sel) {  
    document.getElementById("cb_email").setAttribute("value", sel.options[sel.selectedIndex].text);
   if(document.getElementById("cb_email").getAttribute("name") === "false"){   
   document.getElementById("cb_email").setAttribute("name", "true"); 
   }   
}  
function CBHandler_proxy(sel) {  
    document.getElementById("cb_proxy").setAttribute("value", sel.options[sel.selectedIndex].text);
    if (document.getElementById("cb_proxy").getAttribute("name") === "false") {   
        document.getElementById("cb_proxy").setAttribute("name", "true"); 
    }   
}  
function chkbuttonClick(id) { 
    if (document.getElementById(id).getAttribute("name") === "false") {
        document.getElementById(id).style.background = "#c6900f";
        document.getElementById(id).setAttribute("name", "true");
    }
    else {
        document.getElementById(id).style.background = "#202020";  
        document.getElementById(id).setAttribute("name", "false");  
    } 
}
function hioooooop() { 
    document.getElementById("1.54.133.254:8080").style.backgroundColor = "red";   
}
function addDropdownText(id, item) {
    document.getElementById(id).innerHTML += item;
    alert("hi");
}