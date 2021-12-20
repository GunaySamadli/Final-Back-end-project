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

    $(document).on("click", ".add-fav", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");
        fetch('https://localhost:44318/product/addtofav/' + id)
            .then(response => response.text())
            .then(data => {
                $(this).removeClass('add-fav').addClass('delete-fav');
                $(".fav-container").html(data)
                var count = $("#favorite-fav").data("fav-count")
                $("#fav-count").text(count)
                $(this).css('background', '#B4876E')

            });
    });

    $(document).on("click", ".delete-fav", function (e) {
        e.preventDefault();
        var id = $(this).attr("data-id");

        fetch('https://localhost:44318/product/deletefromfav/' + id)
            .then(response => response.text())
            .then(data => {

                $('.fav').each(function () {
                    if ($(this).attr('data-id') == id) {
                        $(this).removeClass('delete-fav').addClass('add-fav');
                        $(this).css('background', '#FFFFFF');
                    }
                })

                $(".fav-container").html(data)
                var count = $("#favorite-fav").data("fav-count")
                $("#fav-count").text(count)

            });
    })


})
