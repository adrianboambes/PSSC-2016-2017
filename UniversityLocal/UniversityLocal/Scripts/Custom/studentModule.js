var studentModule = function() {

    function setStudentPostData() {
        //var postData = new FormData($("#save-student")[0]);
        var postData = new Object();
        var studentName = $("#student-name-id").val();
        postData.studentName = studentName;

        return postData;
    }

    function setUpdatedStudentPostData()
    {
        var postData = new Object();
        postData.Name = $("#student-name").val();
        postData.Credits = $("#student-credits").val();

        return postData;
    }

    function addStudent() {
        debugger;
        var postData = setStudentPostData();
        ajaxHelper.post("/Student/AddStudent", postData, function(data) {
            commonModule.navigate("/Student/GetAllStudents");

        }, function() {

        });
    }

    function editStudentGet(id) {
        debugger;
        commonModule.navigate("/Student/UpdateStudent?studentId=" + id);
    }

    function editStudentPost(studentId) {
        debugger;
        var postData = setUpdatedStudentPostData();
        postData.RegistrationNumber = studentId;
        ajaxHelper.post("/Student/UpdateStudentPost", postData, function (data) {
            commonModule.navigate("/Student/GetAllStudents");
            },
            function() {

            });
    }

    return {
        addStudent: addStudent,
        setStudentPostData: setStudentPostData,
        editStudentGet: editStudentGet,
        editStudentPost: editStudentPost
    };
}();