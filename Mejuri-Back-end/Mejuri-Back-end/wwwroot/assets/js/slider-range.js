
(function ($) {
    "use strict";

    jQuery(document).ready(function () {
        $(".slider-range").slider({
            range: true,
            min: 10,
            max: 1000,
            values: [10, 1000],
            slide: function (event, ui) {
                $(".amount").val("$" + ui.values[0] + " - $" + ui.values[1]);

                let min = ui.values[0];
                let max = ui.values[1];
                $('#maxPrice').val(max);
                $('#minPrice').val(min);
            }
        });
        $(".amount").val("$" + $(".slider-range").slider("values", 0) +
            " - $" + $(".slider-range").slider("values", 1));

    });
})(jQuery);
