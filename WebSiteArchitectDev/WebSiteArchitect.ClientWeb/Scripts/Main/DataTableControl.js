function ConfigureDataTables() {
    $('.dataTableControl').each(function () {
        $(this).find('table').each(function () {
            $(this).DataTable({
                paging: false,
                scrollY: 300,

            });
            $(this).find('td').each(function () {
                ConfigureDataTablesClick($(this))
            });
            $(this).find('tr').each(function () {
                $(this)[0].addEventListener('contextmenu', function (ev) {
                    ev.preventDefault();
                    ShowActionMenu($(this), event)
                    return false;
                }, false);
            });
        });
        var input = document.createElement("input");
        input.style.display = "none";
        input.setAttribute("selectedItems", "");
        $(this)[0].appendChild(input);
    });
}

function ConfigureDataTablesClick(obj) {
    $(obj).on('click', function (e) {
        
        var row = $(this).closest('tr');
        if ($(row).hasClass('scSelectedRow')) {
            $(row).removeClass('scSelectedRow');
            $(row).find('td').each(function () {
                $(this).removeClass(' scSelectedItem');
            });
        }
        else {
            if (!e.ctrlKey) {
                $(row).closest('table').find('.scSelectedRow').each(function () {
                    $(this).removeClass('scSelectedRow');
                    $(this).find('td').each(function () {
                        $(this).removeClass(' scSelectedItem');
                    });
                });
            }
            $(row).addClass(' scSelectedRow');
            $(row).find('td').each(function () {
                $(this).addClass(' scSelectedItem');
            });
        }
         
    });
}

function UpdateHiddenInput(sender, attribute, value, action) {
    var table = $(sender).closest(',dataTableControl');
    var input = table.children('input');
    if ($(input).attr(attribute) != null && $(input).attr(attribute) != undefined) {
        switch (action) {
            case "add":
                $(input).attr(attribute, $(input).attr(attribute) + "|" + value);
                break;
            case "remove":
                $(input).attr(attribute, $(input).attr(attribute).replace(value,""));
                break;
            case "new":
                $(input).attr(attribute, value);
                break;
            case "clear":
                $(input).attr(attribute, "");
                break;
        } 
    }

}

function ShowActionMenu(sender, event) {
    var menu = $('.ActionMenu');
    menu.css('left', event.clientX + "px");
    menu.css('top', event.clientY + "px");
    menu.show();
    $(document).mouseup(function (e) {
        if (!menu.is(e.target) && menu.has(e.target).length === 0) {
            menu.hide();
        }
    });
}