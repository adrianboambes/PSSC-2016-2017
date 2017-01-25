var deanshipModule = function () {
    function setfacultyPostData() {
        var postData = new Object();
        postData.Id = "312c95fd-fcb4-40bc-b218-25b6ce04a4w1";
        postData.Name = "Automatica si calculatoare";
        postData.Website = "www.ac.com";

        return postData;
    }

    function setMajorPostData() {
        var postData = new Object();
        postData.Id = "777c95fd-fcb4-40bc-b218-25b6ce04a5y7";
        postData.Name = "Ingineria Sistemelor";
        postData.Website = "www.is.com";

        return postData;
    }

    function addFacultyPost() {
        debugger;
        var postData = new Object();
        postData.Name = $("#faculty-name-button").val();
        postData.Website = $("#faculty-website-name-button").val();

        ajaxHelper.post("/Deanship/AddFaculty", postData, function (data) {
            commonModule.navigate("/Deanship/GetAllFaculties");
        }, function () {

        });
    }

    function addMajorPost() {
        debugger;
        var postData = setMajorPostData();
        ajaxHelper.post("/Deanship/AddMajor", postData, function (data) {

        }, function () {

        });
    }

    return {
        addFacultyPost: addFacultyPost,
        addMajorPost: addMajorPost
    };

}();