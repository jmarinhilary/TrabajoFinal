(function ($) {

    $(document).ready(function () {

        var kwindowAlert,
            kwindowConfirm,
            kwindowSettings = { resizable: false, modal: true, maxWidth: '400px', minWidth: '250px',title:'' };
        
        $.extend(window, {
            alerta: function (message, context, settings) {

                if (!kwindowAlert || settings) {
                    kwindowAlert = $("<div id='alerta' style='text-align:center'><p id='content-alert-id'></p><a href='javascript:' class='k-button' style='margin: 5px;width: 50px;'>OK</a></div>");
                    $.extend(kwindowSettings, settings);
                    $(kwindowAlert).kendoWindow(kwindowSettings);
                }

                $(kwindowAlert)
                    .find("#content-alert-id")
                    .text(message).end()
                    .find("a.k-button")
                    .unbind("click")
                    .bind("click", function () {
                        kwindowAlert.data("kendoWindow").close();
                        if (context) {
                            context();
                        }
                    });

                kwindowAlert.data("kendoWindow")
                    .center()
                    .open();
            },

            confirmacion: function (message, context, settings) {
                var defaultSettings = {
                    TextButtonYes: "Si", 
                    TextButtonNo: "No"
                }

                $.extend(defaultSettings, settings);

                if (!kwindowConfirm || settings) {
                    kwindowConfirm = $("<div id='confirmacion' style='text-align:center;display:inline-block; width: 250px'><p id='content-alert-id'></p><div><a id='btnOk'href='javascript:' class='k-button' style='margin: 5px;width: 50px;'>" + defaultSettings.TextButtonYes + "</a><a id='btnClose' href='javascript:' class='k-button' style='margin: 5px;width: 50px;'>" + defaultSettings.TextButtonNo + "</a></div></div>");
                    $.extend(kwindowSettings, settings);
                    $(kwindowConfirm).kendoWindow(kwindowSettings);
                }

                $(kwindowConfirm).find("#content-alert-id")
                    .text(message).end()
                    .find("#btnOk")
                    .unbind("click")
                    .bind("click", function () {
                        if (context) context();
                        kwindowConfirm.data("kendoWindow").close();
                    })
                    .next("#btnClose").click(function () {
                        kwindowConfirm.data("kendoWindow").close();
                    });

                kwindowConfirm.data("kendoWindow")
                    .center()
                    .open();
            }
        });

        var KendoPopup = {
            init: function () {

                $.fn.InitKendoPopup = function (seetings) {
                    var _seetings = { resizable: false, actions: ["Minimize", "Close"], visible:false }

                    $.extend(_seetings, seetings);

                    this.kendoWindow(_seetings);
                    return this;
                },

                $.fn.OpenKendoPopup = function (seetings, showLoading) {
                    var wnd = this.data("kendoWindow"),
                        isOpen = !wnd ? false : !wnd.element.is(":hidden");

                    if (!isOpen) {
                        var _seetings = { resizable: false, actions: ["Close"], visible: true, position: { left: "20%" , top : "15%"} }
                        $.extend(_seetings, seetings);
                        showLoading && kendo.ui.progress($(this), showLoading);
                        
                        this.kendoWindow(_seetings);
                        this.data("kendoWindow")
                            
                            .open();
                    }
                    return this;
                },

                //
                $.fn.OpenKendoPopupLC = function (seetings, showLoading) {
                    var wnd = this.data("kendoWindow"),
                        isOpen = !wnd ? false : !wnd.element.is(":hidden");

                    if (!isOpen) {
                        var _seetings = { resizable: false, visible: true }
                        $.extend(_seetings, seetings);
                        showLoading && kendo.ui.progress($(this), showLoading);

                        this.kendoWindow(_seetings);
                        this.data("kendoWindow")
                            .center()
                            .open();
                    }
                    return this;
                },
                //
                $.fn.CloseKendoPopup = function () {
                    kendo.ui.progress($(this), false);
                    this.data("kendoWindow").close();
                    return this;
                },

                $.fn.SetOptions = function (settings) {
                    this.data("kendoWindow").setOptions(settings);
                    return this;
                }
            }
        }

        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "25000",
            "hideDuration": "25000",
            "timeOut": "25000",
            "extendedTimeOut": "25000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut",
            "closeHtml": '<button type="button" class="toast-close-button">×</button>'
        }

        var toastrPlugin = {
            notify: function (type, message, title, seconds) {
                return toastr[type](message, title);
            }
        };

        var appLoader = {
            loader: function (selector) {
                return {
                    show: function (showIcon) {
                        kendo.ui.progress($(selector), true);
                        showIcon || $("div.k-loading-image").removeClass("k-loading-image");
                    },

                    hide: function () {
                        kendo.ui.progress($(selector), false);
                    }
                }
            }
        }

        KendoPopup.init();
        kendo.culture("es-PE");

        $.extend(window, toastrPlugin, appLoader)
    });

})(jQuery)
