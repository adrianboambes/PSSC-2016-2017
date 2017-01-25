using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using AutoMapper;
using Commands;
using University.Models.StudyYear;

namespace University.Services
{
    public class StudentService
    {
        public void ListStudents()
        {
        //    var serializer = new JavaScriptSerializer();

        //    var events = new ArrayList();//Todo replace with :   new EventRepository().All();

        //    foreach (var e in events)
        //    {
        //        var eventInfo = new GenericEventWrapper();

        //        switch (eventInfo.Action)
        //        {
        //            case "CreateEvent":
        //                //here we must initialize the eventInfo object in order to retrieve the list of events to the view
        //                break;
        //            case "UpdateEvent":
        //                //here we must initialize the eventInfo object in order to retrieve the list of events to the view
        //                break;

        //        }
        //    }
        }

        public void AddStudent(Student student)
        {
            var createStudentCommand = new CreateStudentCommand(student);
            Mapper.Map(student, createStudentCommand);

            //var commandResult = await new CommandDispatcher(NinjectWebCommon.cre).Dispatch(createStudentCommand);
        }
    }
}
