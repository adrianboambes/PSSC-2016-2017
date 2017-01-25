var laboratoryModule = function () {
    function setlaboratoryPostData() {
        var postData = new Object();
        postData.ID = "123c95fd-fcb4-40bc-b218-25b6ce04a5e8";
        postData.Name = "Laborator Rezistenta materialelor";
        postData.ContentLink = "www.laboratorrezistentamaretialelor.com";

        return postData;
    }

    function addLaboratoryPost() {
        debugger;
        var postData = setlaboratoryPostData();
        ajaxHelper.post("/StudyYear/AddLaboratory", postData, function (data) {
            commonModule.navigate("/StudyYear/AddLaboratory");
        }, function () {

        });
    }

    return {
        addLaboratoryPost: addLaboratoryPost
    };

}();