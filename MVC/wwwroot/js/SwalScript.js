window.onload = function () {
    var message = document.getElementById("message").innerText;
    var type = document.getElementById("type").innerText;

    Swal.fire({
        text: message.toString(),
        icon: type.toString(),
    })
}
