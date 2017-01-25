var teacherModule = function() {
    
    function setTeacherPostData() {
        var postData = new Object();
        var teacherName = $("#teacher-name").val();
        postData.teacherName = teacherName;
        return postData;
    }

    function addTeacherGet() {
        commonModule.navigate("/Teacher/Add");
    }

    function addTeacherPost() {
        debugger;
        var postData = setTeacherPostData();
        ajaxHelper.post("/Teacher/AddTeacher", postData, function(data) {
            commonModule.navigate("/Teacher/GetAll");
        }, function() {

        });
    }

    return {
        addTeacherPost: addTeacherPost,
        addTeacherGet: addTeacherGet
    };
}();