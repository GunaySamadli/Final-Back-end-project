$(document).ready(function () {


    $(document).on("click", ".add-basket", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");


        fetch('https://localhost:44318/product/addtobasket/' + id)
            .then(response => response.text())
            .then(data => {

                $(".basket-body").html(data)
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
                $(".cart-block").html(data)
                var count = $("#favorite").data("favorite-count")
                $("#favorite-count").text(count)
            });
    })

})
