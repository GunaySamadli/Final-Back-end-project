
var ebBtn = document.getElementById("mySizeChart");

// Get the <span> element that closes the modal
var ebSpan = document.getElementsByClassName("ebcf_close")[0];


// When the user clicks the button, open the modal 
ebBtn.onclick = function () {
    ebModal.style.display = "block";
}
document.querySelector('.register').addEventListener('click', function (e) {
    e.preventDefault();
    (async () => {
        const rawResponse = await fetch('https://localhost:44318/account/register', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ a: 1, b: 'Textual content' })
        });
        const content = await rawResponse.json();

        console.log(content);
    })();
})
