$(document).ready(function () {
    $(document).on("click", ".btn-item-delete", function (e) {
        e.preventDefault();

        var url = $(this).attr("href");

        
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            console.log(result)
            if (result.value) {
                fetch(url)
                    .then(response => response.json())
                    .then(data => {
                        console.log(data)
                        if (data.status == 200) {
                            window.location.reload(true)
                        }
                        else {
                            console.log(data.status)
                            Swal.fire(
                                'Error!',
                                'Your file has not been deleted!',
                                'error'
                            )
                        }
                    })

            }
        })


    })

    $(document).on("click", ".remove-img-box", function () {
        console.log("salam")
        $(this).parent().remove()
    });
})

