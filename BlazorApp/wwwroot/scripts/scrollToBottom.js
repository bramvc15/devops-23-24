function scrollToBottom() {
    var objDiv = document.getElementsByClassName("chatbox-content")[0];
    objDiv.scrollTo({
        top: objDiv.scrollHeight,
        behavior: 'smooth'
    });
}