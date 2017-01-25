var commonModule = function () {

    var numberOfItems = 10;
    function isDataValid(data) {
        return typeof (data) != "undefined" && data != null && data.Success;
    }

    function numberOfItemsPerPage() {
        return numberOfItems;
    }

    function emptyGuid() {
        return "00000000-0000-0000-0000-000000000000";
    }

    function guid() {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + "-" + s4() + "-" + s4() + "-" +
          s4() + "-" + s4() + s4() + s4();
    }

    function navigate(endPointUrl) {
        window.location.href = endPointUrl;
    }

    function validate(uploadFile, validFileExtensions) {
        var oinput = uploadFile;
        var sFileName = oinput.name;
        if (sFileName.length > 0) {
            for (var j = 0; j < validFileExtensions.length; j++) {
                var sCurExtension = validFileExtensions[j];
                if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                    return true;
                }
            }
        }
        return false;
    }

    function validateMp4(uploadMp4) {
        return validate(uploadMp4, [".mp4"]);
    }

    function validatePng(uploadPng) {
        return validate(uploadPng, [".png"]);
    }

    function validateJpg(uploadJpg) {
        return validate(uploadJpg, [".jpg", ".JPG", ".jpeg", ".JPEG"]);
    }

    function validateSrt(uploadSrt) {
        return validate(uploadSrt, [".srt"]);
    }

    function validateVtt(uploadVtt) {
        return validate(uploadVtt, [".vtt"]);
    }

    function validatePdf(uploadPdf) {
        return validate(uploadPdf, [".pdf"]);
    }

    function validateCsv(uploadCsv) {
        return validate(uploadCsv, [".csv"]);
    }

    function refreshPage(refreshUrl, tableName, pageNumber) {

        ajaxHelper.getWithoutData(refreshUrl,
            function (partialView) {
                $(tableName).html(partialView);
                commonModule.toggleLoadingOff("#overlay", "#loading");
                siteModule.computeFooterPosition();
                pageChangedSuccessCallBack(pageNumber);
            });
    };

    function showOverview(refreshUrl, tableName) {
        ajaxHelper.getWithoutData(refreshUrl,
            function (partialView) {

                $(tableName).html(partialView);
            });
    }

    function mark(id, endPointUrl, refreshUrl, tableName, successCallback, errorCallback) {

        var postData = new Object();
        postData.id = id;

        ajaxHelper.post(endPointUrl, postData, function (data) {
            if (isDataValid(data)) {
                refreshPage(refreshUrl, tableName);
                if (typeof (successCallback) == "undefined" || successCallback == null) {
                    return;
                }
                successCallback();
            } else {
                toastrModule.showError("An error occurred.");
                if (typeof (errorCallback) == "undefined" || errorCallback == null) {
                    return;
                }
                errorCallback();
            }
        }, function () {
            toastrModule.showError("An error occurred.");
        });
    };

    function baseEdit(id, endPointUrl) {
        window.location.href = endPointUrl + "?id=" + id;
    };

    function pageChangedSuccessCallBack(pageNumber) {
        debugger;
        var boldPageNumber = "bold-page-number";
        $(".pagination-number").removeClass(boldPageNumber);
        $(".change-page" + pageNumber + "-button").addClass(boldPageNumber);
    }


    function toggleLoadingOn(loadingBackground, loadingImage) {
        $(loadingBackground).show();
        $(loadingImage).show();
    }

    function toggleLoadingOff(loadingBackground, loadingImage) {
        $(loadingBackground).hide();
        $(loadingImage).hide();
        $("#loading-message").html("");
        $("#loading-message").hide();
    }

    function toggleLoadingWithMessageOn(message) {
        $("#loading-message").html(message);
        $("#loading-message").show();
        toggleLoadingOn("#overlay", "#loading");
    }

    function validateForm(formName) {
        var $form = $("#" + formName);
        $form.validate();
        return $form.valid();
    };

    function validateAjaxForm(formName) {
        var $form = $("#" + formName);
        $form.validate();

        $form.unbind();
        $form.data("validator", null);
        $.validator.unobtrusive.parse($form);

        return $form.valid();
    }

    return {
        guid: guid,
        toggleLoadingWithMessageOn: toggleLoadingWithMessageOn,
        mark: mark,
        baseEdit: baseEdit,
        toggleLoadingOn: toggleLoadingOn,
        toggleLoadingOff: toggleLoadingOff,
        validateForm: validateForm,
        validateAjaxForm: validateAjaxForm,
        navigate: navigate,
        refreshPage: refreshPage,
        isDataValid: isDataValid,
        showOverview: showOverview,
        numberOfItemsPerPage: numberOfItemsPerPage,
        emptyGuid: emptyGuid,
        validateVtt: validateVtt,
        validatePdf: validatePdf,
        validateCsv: validateCsv,
        validateJpg: validateJpg,
        validatePng: validatePng,
        validateMp4: validateMp4,
        validateSrt: validateSrt,
        pageChangedSuccessCallBack: pageChangedSuccessCallBack
    };
}();