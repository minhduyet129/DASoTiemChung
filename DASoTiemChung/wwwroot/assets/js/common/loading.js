"use strict";

(function () {
    const dataKey = "FLoading";

    $.fn.FLoading = function (methodName) {
        switch (methodName) {
            case "show":
                return this.each(function () {
                    let originPositionCssValue = $.trim($(this).css("position")).toLowerCase();

                    if (originPositionCssValue !== "relative") {
                        $(this).css({
                            position: $(this).hasClass("sidebar-wrapper") ? "fixed" : "relative"
                        });
                    }

                    let jqLoading = $(`<div class="position-absolute top-50 start-50 translate-middle w-100 h-100" style="background-color: rgba(255, 255, 255, 0.9); z-index: 9999;">
                                            <div class="position-absolute top-50 start-50 translate-middle">
                                                <!--<div class="spinner-grow text-primary" role="status">
                                                    <span class="visually-hidden">Loading...</span>
                                                </div>
                                                <div class="spinner-grow text-danger" role="status">
                                                    <span class="visually-hidden">Loading...</span>
                                                </div>
                                                <div class="spinner-grow text-success" role="status">
                                                    <span class="visually-hidden">Loading...</span>
                                                </div>-->
                                                <img src="/assets/vendors/svg-loaders/grid.svg" class="me-4" style="width: 3rem" alt="audio">
                                            </div>
                                        </div>`);

                    $.data(this, dataKey, {
                        jqLoading,
                        originPositionCssValue,
                    });

                    $(this).append(jqLoading);
                });
            case "hide":
                return this.each(function () {
                    let FLoadingData = $.data(this, dataKey);

                    $(this).css({
                        position: FLoadingData.originPositionCssValue,
                    });

                    if (FLoadingData.jqLoading) {
                        FLoadingData.jqLoading.remove();
                    }

                    $.removeData(this, dataKey);
                });

        }
    }
})()