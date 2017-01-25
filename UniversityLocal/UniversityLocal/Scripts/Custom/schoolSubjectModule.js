var schoolSubjectModule = function () {
    function setSchoolSubjectPostData() {
        debugger;
        //var postData = new List < Object > () => {
        //postData.Id = new Object();
        //postData.Id.UniqueId = "2157bc8d-0c41-4112-af38-3690d62f0072";
        //postData.Name.Name = "John";
        //postData.ExamProportion = 60;
        //postData.Credits = 5;
        //postData.EvaluationType = "ExamSchoolSubject";

        var postData = new Object();
        postData.Name = $("#school-subject-name-input").val();
        postData.ExamProportion = $("#school-subject-exam-proportion-input").val();
        postData.Credits = $("#school-subject-credits-input").val();
        postData.EvaluationType = $("#school-subject-evaluation-type-input").val();//means that is an exam

        return postData;
    }

    function addSchoolSubjectPost() {
        debugger;
        var postData = setSchoolSubjectPostData();
        ajaxHelper.post("/StudyYear/AddSchoolSubject", postData, function (data) {
            commonModule.navigate("/StudyYear/GetAllSchoolSubjects");
        }, function () {

        });
    }

    return {
        addSchoolSubjectPost: addSchoolSubjectPost
    };
}();