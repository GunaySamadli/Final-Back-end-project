var ebModal = document.getElementById('mySizeChartModal');

// Get the button that opens the modal
var ebBtn = document.getElementById("mySizeChart");

// Get the <span> element that closes the modal
var ebSpan = document.getElementsByClassName("ebcf_close")[0];


// When the user clicks the button, open the modal 
ebBtn.onclick = function () {
    ebModal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
ebSpan.onclick = function () {
    ebModal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == ebModal) {
        ebModal.style.display = "none";
    }
}
let forget = document.querySelector(".forgot-ans")

forget.addEventListener("click", function (e) {
    e.preventDefault();
    let forgetModal = document.querySelector("#forget");
    forgetModal.style.display = "block"
})