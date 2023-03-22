using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Entities
{
    public class LoadRow
    {
        public int SubjectSemesterId { get; set; }
        public string SubjectName { get; set; }
        public string ProfessorFullName { get; set; }
        public int ProfessorId { get; set; }
        public int Semester { get; set; }
        public int SemesterVisible { get; set; }
        public int SubjectSpecialityId { get; set; }

        public static List<LoadRow> GetRows(string specialityId, int qualificationId, int startYear, string academicYear,List<Subject> subjects)
        {
            subjects.Clear();
            List<LoadRow> loads = new List<LoadRow>();
            loads.Clear();
            var items = CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpeciality.SpecialityId == specialityId && s.SubjectSpeciality.QualificationId == qualificationId && s.SubjectSpeciality.StartYear == startYear && s.Syllabu.AcademicYear == academicYear).ToList();
            foreach (var item in items)
            {
                if (item.SubjectProfessors.ToList().Count > 0)
                {
                    var subjectLoads = item.SubjectProfessors.ToList();
                    foreach (var subjectLoad in subjectLoads)
                    {
                        if (loads.Where(l => l.SubjectName == subjectLoad.SubjectSemester.SubjectSpeciality.Subject.Name && l.Semester == subjectLoad.SubjectSemester.Semester && l.ProfessorId == subjectLoad.ProfessorId).FirstOrDefault() == null)
                        {
                            LoadRow load = new LoadRow();
                            load.SubjectSpecialityId = subjectLoad.SubjectSemester.SubjectSpecialityId;
                            load.SubjectSemesterId = subjectLoad.SubjectSemesterId;
                            load.ProfessorId = subjectLoad.ProfessorId;
                            load.ProfessorFullName = subjectLoad.Professor.FullName;
                            load.SubjectName = subjectLoad.SubjectSemester.SubjectSpeciality.Subject.Name;
                            load.Semester = subjectLoad.SubjectSemester.Semester;
                            int cours = Int32.Parse(academicYear.Substring(0, 4)) - startYear;
                            switch (cours)
                            {
                                case 0:
                                    if (subjectLoad.SubjectSemester.Semester == 1)
                                        load.SemesterVisible = 1;
                                    if (subjectLoad.SubjectSemester.Semester == 2)
                                        load.SemesterVisible = 2;
                                    break;

                                case 1:
                                    if (subjectLoad.SubjectSemester.Semester == 1)
                                        load.SemesterVisible = 3;
                                    if (subjectLoad.SubjectSemester.Semester == 2)
                                        load.SemesterVisible = 4;
                                    break;

                                case 2:
                                    if (subjectLoad.SubjectSemester.Semester == 1)
                                        load.SemesterVisible = 5;
                                    if (subjectLoad.SubjectSemester.Semester == 2)
                                        load.SemesterVisible = 6;
                                    break;

                                case 3:
                                    if (subjectLoad.SubjectSemester.Semester == 1)
                                        load.SemesterVisible = 7;
                                    if (subjectLoad.SubjectSemester.Semester == 2)
                                        load.SemesterVisible = 8;
                                    break;
                            }
                            loads.Add(load);
                            LoadRow searchRow = loads.Where(l => l.SubjectName == load.SubjectName && l.Semester == load.Semester && l.ProfessorId == 0).FirstOrDefault();
                            if (searchRow != null)
                                loads.Remove(searchRow);
                            if (subjects.Where(s => s.Name == item.SubjectSpeciality.Subject.Name).FirstOrDefault() == null)
                            {
                                Subject subject = new Subject();
                                subject.Name = item.SubjectSpeciality.Subject.Name;
                                subjects.Add(subject);
                            }
                        }
                    }
                }
                else
                {
                    if (loads.Where(l => l.SubjectName == item.SubjectSpeciality.Subject.Name && l.Semester == item.Semester && l.ProfessorId != 0).FirstOrDefault() == null)
                    {
                        if (loads.Where(l => l.SubjectName == item.SubjectSpeciality.Subject.Name && l.Semester == item.Semester).FirstOrDefault() == null)
                        {
                            LoadRow load = new LoadRow();
                            load.SubjectSpecialityId = item.SubjectSpecialityId;
                            load.SubjectSemesterId = item.Id;
                            load.ProfessorFullName = "Преподаватель не назначен";
                            load.SubjectName = item.SubjectSpeciality.Subject.Name;
                            load.Semester = item.Semester;
                            int cours = Int32.Parse(academicYear.Substring(0, 4)) - startYear;
                            switch (cours)
                            {
                                case 0:
                                    if (item.Semester == 1)
                                        load.SemesterVisible = 1;
                                    if (item.Semester == 2)
                                        load.SemesterVisible = 2;
                                    break;

                                case 1:
                                    if (item.Semester == 1)
                                        load.SemesterVisible = 3;
                                    if (item.Semester == 2)
                                        load.SemesterVisible = 4;
                                    break;

                                case 2:
                                    if (item.Semester == 1)
                                        load.SemesterVisible = 5;
                                    if (item.Semester == 2)
                                        load.SemesterVisible = 6;
                                    break;

                                case 3:
                                    if (item.Semester == 1)
                                        load.SemesterVisible = 7;
                                    if (item.Semester == 2)
                                        load.SemesterVisible = 8;
                                    break;
                            }
                            loads.Add(load);
                            if (subjects.Where(s => s.Name == item.SubjectSpeciality.Subject.Name).FirstOrDefault() == null)
                            {
                                Subject subject = new Subject();
                                subject.Name = item.SubjectSpeciality.Subject.Name;
                                subjects.Add(subject);
                            }
                        }
                    }
                }
            }
            loads = loads.OrderBy(l => l.SubjectName).ThenBy(l => l.Semester).ToList();
            return loads;
        }
    }
}
