var courseModule = function() {
    function setCoursePostData() {
        var postData = new Object();
        postData.ID = "064c95fd-fcb4-40bc-b218-25b6ce04a6e1";
        postData.Name = "Rezistenta materialelor";
        postData.ContentLink = "www.rezistentamaretialelor.com";

        return postData;
    }

    function addCoursePost() {
        debugger;
        var postData = setCoursePostData();
        ajaxHelper.post("/StudyYear/AddCourse", postData, function (data) {
            commonModule.navigate("/StudyYear/AddCourse");
        }, function () {

        });
    }

    return {
        addCoursePost: addCoursePost
    };

}();