(function ($, window) {

    $(document).ready(function () {
        $(".currency").change(setCurrencyFormat).click(selectText);
        $(".4currency").change(setCurrencyFormat4Dec).click(selectText);
        $(".6currency").change(setCurrencyFormat6Dec).click(selectText);
    })

    var publicMethods = {
        setCurrencyFormat: function () {
            $(".currency").each(function () {
                setCurrencyFormat.call(this);
            })
        },
        setCurrencyFormat4Dec: function () {
            $(".4currency").each(function () {
                setCurrencyFormat4Dec.call(this);
            })
        },
        setCurrencyFormat6Dec: function () {
            $(".6currency").each(function () {
                setCurrencyFormat6Dec.call(this);
            })
        },
        setCurrencyFormatWithoutDefault: function () {
            $(".ncurrency").each(function () {
                setCurrencyFormatWithoutDefault.call(this);
            })
        },
        setCurrencyFormatWithoutRounding: function () {
            $(".ncurrency").each(function () {
                setCurrencyFormatWithoutRounding.call(this);
            })
        },
        update: function () {
        	$(".currency").change(setCurrencyFormat).click(selectText);
        	$(".4currency").change(setCurrencyFormat4Dec).click(selectText);
        	$(".6currency").change(setCurrencyFormat6Dec).click(selectText);
        }
    },

    setCurrencyFormat = function (e) {
        setFormat.call(this, 2);
    },

    setCurrencyFormat4Dec = function (e) {
        setFormat.call(this, 4);
    },

    setCurrencyFormat6Dec = function (e) {
        setFormat.call(this, 6);
    },

    setCurrencyFormatWithoutDefault = function () {
        var $element = $(this),
            value = $element.is("input") ? $element.val() : $element.text();
        if (isNaN(value)) {
            return;
        }
        setCurrencyFormat.call(this);
    },

    setCurrencyFormatWithoutRounding = function () {
        var $element = $(this),
            value = $element.is("input") ? $element.val() : $element.text();
        if (isNaN(value)) {
            return;
        }
        setFormat.call(this);
    },

    setFormat = function (decimal) {
        var value = get.call($(this)).replace(/,/g, '')
        formattedValue = getFormattedValue(value, decimal);
        set.call(this, formattedValue);
        $(this)
            .css("text-align", "right")
            .attr("maxlength", "35");
    },

    getFormattedValue = function (value, round) {
        return round ? parseFloat(value).toFixed(round).replace(/\d(?=(\d{3})+\.)/g, '$&,')
            : (hasDecimals(value) ? value.replace(/\d(?=(\d{3})+\.)/g, '$&,') : parseFloat(value).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,'));
    },

    get = function () {
        var $element = $(this),
            value = $element.is("input") ? $element.val() : $element.text();
        return (value == '' || isNaN(value.split(',').join(''))) ? '0' : value;
    },

    set = function (value) {
        var $element = $(this);
        $element.is("input") ? $element.val(value) : $element.text(value);
    },

    selectText = function (e) {
        this.select();
    },

    getValueOrDefault = function (value) {
        return value == '' || isNaN(value) ? 0 : parseFloat(value);
    },

    hasDecimals = function (num) {
        return (num.split('.')[1] || []).length;
    };

    $.fn.valDec = function (value, decimal) {
        if (typeof (value) !== "undefined") {
            decimal = !decimal ? 2 : decimal;
            set.call(this, getFormattedValue(value, decimal));
        } else {
            return getValueOrDefault(parseFloat($(this).val().replace(/,/g, '')));
        }
    }

    $.extend(window, publicMethods)

})(jQuery, window)