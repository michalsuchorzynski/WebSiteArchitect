function SetRowElementsHeight() {
    $('.row').each(function () {
        var height = 0
        $(this).children().each(function () {
            if ($(this).is(":visible")) {
                var currentHeight = $(this).height();
                if (currentHeight > height) {
                    height = currentHeight;
                }
            }
        });
        if ($(this).is(":visible")) {
            $(this).children().each(function () {
                $(this).height(height);
            });
        }
        height = 0;
    });
}