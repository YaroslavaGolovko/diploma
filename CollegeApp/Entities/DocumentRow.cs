using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Entities
{
    public class DocumentRow
    {
        public int Id { get; set; }
        public int SubjectSemesterId { get; set; }
        public int DocumentId { get; set; }
        public string ProfessorFullName { get; set; }
        public int ProfessorId { get; set; }
        public string SubjectName { get; set; }
        public string Note { get; set; }
        public Syllabu Syllabus { get; set; }
        public string SpecialityId { get; set; }
        public string Qualification { get; set; }
        public string AcademicYear { get; set; }
        public int StartYear { get; set; }
        public int SemesterVisible { get; set; }
        public int Semester { get; set; }
        public int WorkProgramElectronicId { get; set; }
        public DateTime WorkProgramElectronicDate { get; set; }
        public bool WorkProgramElectronicIsExist { get; set; }
        public int WorkProgramTypewriterId { get; set; }
        public DateTime WorkProgramTypewriterDate { get; set; }
        public bool WorkProgramTypewriterIsExist { get; set; }
        public int CalendarThematicPlanElectronicId { get; set; }
        public DateTime CalendarThematicPlanElectronicDate { get; set; }
        public bool CalendarThematicPlanElectronicIsExist { get; set; }
        public int CalendarThematicPlanTypewriterId { get; set; }
        public DateTime CalendarThematicPlanTypewriterDate { get; set; }
        public bool CalendarThematicPlanTypewriterIsExist { get; set; }
    }
}
