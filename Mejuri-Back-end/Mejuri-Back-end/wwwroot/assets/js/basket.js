$(document).ready(function () {

    $(document).on("click", ".add-basket", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        fetch('https://localhost:44318/product/addtobasket/' + id)
            .then(response => response.text())
            .then(data => {

                $(".basket").html(data)
                var count = $("#favorite").data("favorite-count")
                $("#favorite-count").text(count)
            });
    });

    $(document).on("click", ".delete", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");


        fetch('https://localhost:44318/product/deletefrombasket/' + id)
            .then(response => response.text())
            .then(data => {

                console.log(data);
                $(".basket").html(data)
                var count = $("#favorite").data("favorite-count")
                $("#favorite-count").text(count)
            });
    })

    let ranks = document.querySelectorAll('.product-ratting .rank');
    ranks.forEach(function (elem, index) {
        elem.addEventListener('click', function () {
            let rank = index + 1;
            document.querySelector('.rate').value = rank;
            for (let i = 0; i < rank; i++) {
                ranks[i].style.color = '#cb3421';
            }
        })
    });

   

})
