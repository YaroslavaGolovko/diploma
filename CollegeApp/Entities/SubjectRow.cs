using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp.Entities
{
    public class SubjectRow
    {
        public int IdSubjectSpeciality { get; set; }
        public int GroupNumber { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string Exam { get; set; }
        public string Offset { get; set; }
        public string DiffOffset { get; set; }
        public string CourseProject { get; set; }
        public string CourseWork { get; set; }
        public string TestWork { get; set; }
        public string OtherAttestation { get; set; }
        public string Semester1MaxLoad { get; set; }
        public string Semester1IndependentLoad { get; set; }
        public string Semester1ConsultationLoad { get; set; }
        public string Semester1NecessaryLoad { get; set; }
        public string Semester1LectureLoad { get; set; }
        public string Semester1PracticeLoad { get; set; }
        public string Semester1LaboratoryLoad { get; set; }
        public string Semester1SeminarLoad { get; set; }
        public string Semester1ProjectionLoad { get; set; }
        public string Semester1IndProjectLoad { get; set; }
        public string Semester2MaxLoad { get; set; }
        public string Semester2IndependentLoad { get; set; }
        public string Semester2ConsultationLoad { get; set; }
        public string Semester2NecessaryLoad { get; set; }
        public string Semester2LectureLoad { get; set; }
        public string Semester2PracticeLoad { get; set; }
        public string Semester2LaboratoryLoad { get; set; }
        public string Semester2SeminarLoad { get; set; }
        public string Semester2ProjectionLoad { get; set; }
        public string Semester2IndProjectLoad { get; set; }

        public static void SaveRow(List<SubjectRow> _currentRows, Syllabu _currentPlan)
        {
            var rows = _currentRows;
            var qualificationId = _currentPlan.Group.QualificationId;
            var start = _currentPlan.Group.StartYear;
            var groups = CollegeBaseEntities.GetContext().Groups.Where(g => g.QualificationId == qualificationId && g.StartYear == start).ToList();
            foreach (Group group in groups)
            {
                var number = group.Number;
                var startYear = group.StartYear;
                var academicYear = _currentPlan.AcademicYear;
                var syllabus = CollegeBaseEntities.GetContext().Syllabus.Where(s => s.GroupNumber == group.Number && s.AcademicYear == _currentPlan.AcademicYear).FirstOrDefault();
                if (syllabus != null)
                {
                    int id = syllabus.Id;
                    foreach (SubjectRow row in rows)
                    {
                        SubjectSpeciality _currentRow = CollegeBaseEntities.GetContext().SubjectSpecialities.Where(s => s.Id == row.IdSubjectSpeciality && s.QualificationId == qualificationId && s.StartYear == startYear).FirstOrDefault();
                        int rowNumber = number;
                        if (_currentRow != null)
                        {
                            var _currentAttestations = _currentRow.Attestations.ToList();
                            foreach (Attestation attestation in _currentAttestations)
                            {
                                if (row.Exam != null && row.Exam.Length >= 0)
                                {
                                    if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 1 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                    {
                                        if (row.Exam.Length > 0)
                                        {
                                            if (attestation.AttestationFormId == 1)
                                                attestation.Qty = row.Exam;
                                        }
                                        else
                                        {
                                            CollegeBaseEntities.GetContext().Attestations.Remove(attestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (row.Exam.Length > 0)
                                        {
                                            Attestation subjectAttestation = new Attestation();
                                            subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                            subjectAttestation.AttestationFormId = 1;
                                            subjectAttestation.Qty = row.Exam;
                                            subjectAttestation.SyllabusId = id;
                                            CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    CollegeBaseEntities.GetContext().SaveChanges();
                                }
                                if (row.Offset != null && row.Offset.Length >= 0)
                                {
                                    if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 2 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                    {
                                        if (row.Offset.Length > 0)
                                        {
                                            if (attestation.AttestationFormId == 2)
                                                attestation.Qty = row.Offset;
                                        }
                                        else
                                        {
                                            CollegeBaseEntities.GetContext().Attestations.Remove(attestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (row.Offset.Length > 0)
                                        {
                                            Attestation subjectAttestation = new Attestation();
                                            subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                            subjectAttestation.AttestationFormId = 2;
                                            subjectAttestation.Qty = row.Offset;
                                            subjectAttestation.SyllabusId = id;
                                            CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    CollegeBaseEntities.GetContext().SaveChanges();
                                }
                                if (row.DiffOffset != null && row.DiffOffset.Length >= 0)
                                {
                                    if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 3 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                    {
                                        if (row.DiffOffset.Length > 0)
                                        {
                                            if (attestation.AttestationFormId == 3)
                                                attestation.Qty = row.DiffOffset;
                                        }
                                        else
                                        {
                                            CollegeBaseEntities.GetContext().Attestations.Remove(attestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }

                                    }
                                    else
                                    {
                                        if (row.DiffOffset.Length > 0)
                                        {
                                            Attestation subjectAttestation = new Attestation();
                                            subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                            subjectAttestation.AttestationFormId = 3;
                                            subjectAttestation.Qty = row.DiffOffset;
                                            subjectAttestation.SyllabusId = id;
                                            CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    CollegeBaseEntities.GetContext().SaveChanges();
                                }
                                if (row.CourseProject != null && row.CourseProject.Length >= 0)
                                {
                                    if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 4 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                    {
                                        if (row.CourseProject.Length > 0)
                                        {
                                            if (attestation.AttestationFormId == 4)
                                                attestation.Qty = row.CourseProject;
                                        }
                                        else
                                        {
                                            CollegeBaseEntities.GetContext().Attestations.Remove(attestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (row.CourseProject.Length > 0)
                                        {
                                            Attestation subjectAttestation = new Attestation();
                                            subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                            subjectAttestation.AttestationFormId = 4;
                                            subjectAttestation.Qty = row.CourseProject;
                                            subjectAttestation.SyllabusId = id;
                                            CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    CollegeBaseEntities.GetContext().SaveChanges();
                                }
                                if (row.CourseWork != null && row.CourseWork.Length >= 0)
                                {
                                    if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 5 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                    {
                                        if (row.CourseWork.Length > 0)
                                        {
                                            if (attestation.AttestationFormId == 5)
                                                attestation.Qty = row.CourseWork;
                                        }
                                        else
                                        {
                                            CollegeBaseEntities.GetContext().Attestations.Remove(attestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (row.CourseWork.Length > 0)
                                        {
                                            Attestation subjectAttestation = new Attestation();
                                            subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                            subjectAttestation.AttestationFormId = 5;
                                            subjectAttestation.Qty = row.CourseWork;
                                            subjectAttestation.SyllabusId = id;
                                            CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    CollegeBaseEntities.GetContext().SaveChanges();
                                }
                                if (row.TestWork != null && row.TestWork.Length >= 0)
                                {
                                    if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 6 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                    {
                                        if (row.TestWork.Length > 0)
                                        {
                                            if (attestation.AttestationFormId == 6)
                                                attestation.Qty = row.TestWork;
                                        }
                                        else
                                        {
                                            CollegeBaseEntities.GetContext().Attestations.Remove(attestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (row.TestWork.Length > 0)
                                        {
                                            Attestation subjectAttestation = new Attestation();
                                            subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                            subjectAttestation.AttestationFormId = 6;
                                            subjectAttestation.Qty = row.TestWork;
                                            subjectAttestation.SyllabusId = id;
                                            CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    CollegeBaseEntities.GetContext().SaveChanges();
                                }
                                if (row.OtherAttestation != null && row.OtherAttestation.Length >= 0)
                                {
                                    if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 7 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                    {
                                        if (row.OtherAttestation.Length > 0)
                                        {
                                            if (attestation.AttestationFormId == 7)
                                                attestation.Qty = row.OtherAttestation;
                                        }
                                        else
                                        {
                                            CollegeBaseEntities.GetContext().Attestations.Remove(attestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        if (row.OtherAttestation.Length > 0)
                                        {
                                            Attestation subjectAttestation = new Attestation();
                                            subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                            subjectAttestation.AttestationFormId = 7;
                                            subjectAttestation.Qty = row.OtherAttestation;
                                            subjectAttestation.SyllabusId = id;
                                            CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                            CollegeBaseEntities.GetContext().SaveChanges();
                                        }
                                    }
                                    CollegeBaseEntities.GetContext().SaveChanges();
                                }
                            }
                            if (_currentAttestations == null || _currentAttestations.Count == 0)
                            {
                                for (int i = 1; i <= 7; i++)
                                {
                                    if (row.Exam != null && row.Exam.Length >= 0)
                                    {
                                        if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 1 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                        {

                                        }
                                        else
                                        {
                                            if (row.Exam.Length > 0)
                                            {
                                                Attestation subjectAttestation = new Attestation();
                                                subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                                subjectAttestation.AttestationFormId = 1;
                                                subjectAttestation.Qty = row.Exam;
                                                subjectAttestation.SyllabusId = id;
                                                CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                    if (row.Offset != null && row.Offset.Length >= 0)
                                    {
                                        if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 2 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                        {

                                        }
                                        else
                                        {
                                            if (row.Offset.Length > 0)
                                            {
                                                Attestation subjectAttestation = new Attestation();
                                                subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                                subjectAttestation.AttestationFormId = 2;
                                                subjectAttestation.Qty = row.Offset;
                                                subjectAttestation.SyllabusId = id;
                                                CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                    if (row.DiffOffset != null && row.DiffOffset.Length >= 0)
                                    {
                                        if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 3 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                        {

                                        }
                                        else
                                        {
                                            if (row.DiffOffset.Length > 0)
                                            {
                                                Attestation subjectAttestation = new Attestation();
                                                subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                                subjectAttestation.AttestationFormId = 3;
                                                subjectAttestation.Qty = row.DiffOffset;
                                                subjectAttestation.SyllabusId = id;
                                                CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                    if (row.CourseProject != null && row.CourseProject.Length >= 0)
                                    {
                                        if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 4 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                        {

                                        }
                                        else
                                        {
                                            if (row.CourseProject.Length > 0)
                                            {
                                                Attestation subjectAttestation = new Attestation();
                                                subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                                subjectAttestation.AttestationFormId = 4;
                                                subjectAttestation.Qty = row.CourseProject;
                                                subjectAttestation.SyllabusId = id;
                                                CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                    if (row.CourseWork != null && row.CourseWork.Length >= 0)
                                    {
                                        if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 5 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                        {

                                        }
                                        else
                                        {
                                            if (row.CourseWork.Length > 0)
                                            {
                                                Attestation subjectAttestation = new Attestation();
                                                subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                                subjectAttestation.AttestationFormId = 5;
                                                subjectAttestation.Qty = row.CourseWork;
                                                subjectAttestation.SyllabusId = id;
                                                CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                    if (row.TestWork != null && row.TestWork.Length >= 0)
                                    {
                                        if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 6 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                        {

                                        }
                                        else
                                        {
                                            if (row.TestWork.Length > 0)
                                            {
                                                Attestation subjectAttestation = new Attestation();
                                                subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                                subjectAttestation.AttestationFormId = 6;
                                                subjectAttestation.Qty = row.TestWork;
                                                subjectAttestation.SyllabusId = id;
                                                CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                    if (row.OtherAttestation != null && row.OtherAttestation.Length >= 0)
                                    {
                                        if (CollegeBaseEntities.GetContext().Attestations.Where(s => s.SubjectSpecialityId == _currentRow.Id && s.AttestationFormId == 7 && s.Syllabu.GroupNumber == rowNumber).FirstOrDefault() != null)
                                        {

                                        }
                                        else
                                        {
                                            if (row.OtherAttestation.Length > 0)
                                            {
                                                Attestation subjectAttestation = new Attestation();
                                                subjectAttestation.SubjectSpecialityId = _currentRow.Id;
                                                subjectAttestation.AttestationFormId = 7;
                                                subjectAttestation.Qty = row.OtherAttestation;
                                                subjectAttestation.SyllabusId = id;
                                                CollegeBaseEntities.GetContext().Attestations.Add(subjectAttestation);
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                }
                            }

                            var plan = _currentRow.SubjectSemesters.Where(s => s.SyllabusId == id).ToList();

                            if (plan.Count == 0)
                            {
                                SubjectSemester subjectFirstSemester = new SubjectSemester();
                                subjectFirstSemester.SubjectSpecialityId = _currentRow.Id;
                                subjectFirstSemester.Semester = 1;
                                subjectFirstSemester.SyllabusId = id;
                                subjectFirstSemester.TotalQtyHours = 0;
                                CollegeBaseEntities.GetContext().SubjectSemesters.Add(subjectFirstSemester);
                                CollegeBaseEntities.GetContext().SaveChanges();

                                SubjectSemester subjectSecondSemester = new SubjectSemester();
                                subjectSecondSemester.SubjectSpecialityId = _currentRow.Id;
                                subjectSecondSemester.Semester = 2;
                                subjectSecondSemester.SyllabusId = id;
                                subjectSecondSemester.TotalQtyHours = 0;
                                CollegeBaseEntities.GetContext().SubjectSemesters.Add(subjectSecondSemester);
                                CollegeBaseEntities.GetContext().SaveChanges();
                            }

                            plan = _currentRow.SubjectSemesters.Where(s => s.SyllabusId == id).ToList();

                            if (plan != null)
                            {


                                var firstSemester = plan.Where(s => s.Semester == 1).FirstOrDefault();
                                if (firstSemester != null)
                                {
                                    var loads = CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id).ToList();
                                    if (loads != null)
                                    {
                                        foreach (SubjectLoad load in loads)
                                        {
                                            if (row.Semester1MaxLoad != null && row.Semester1MaxLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 1).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1MaxLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 1)
                                                            load.QtyHours = row.Semester1MaxLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1MaxLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 1;
                                                        subjectLoad.QtyHours = row.Semester1MaxLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1IndependentLoad != null && row.Semester1IndependentLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 2).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1IndependentLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 2)
                                                            load.QtyHours = row.Semester1IndependentLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1IndependentLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 2;
                                                        subjectLoad.QtyHours = row.Semester1IndependentLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1ConsultationLoad != null && row.Semester1ConsultationLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 3).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1ConsultationLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 3)
                                                            load.QtyHours = row.Semester1ConsultationLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1ConsultationLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 3;
                                                        subjectLoad.QtyHours = row.Semester1ConsultationLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1NecessaryLoad != null && row.Semester1NecessaryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 4).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1NecessaryLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 4)
                                                            load.QtyHours = row.Semester1NecessaryLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1NecessaryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 4;
                                                        subjectLoad.QtyHours = row.Semester1NecessaryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1LectureLoad != null && row.Semester1LectureLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 5).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1LectureLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 5)
                                                            load.QtyHours = row.Semester1LectureLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1LectureLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 5;
                                                        subjectLoad.QtyHours = row.Semester1LectureLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1PracticeLoad != null && row.Semester1PracticeLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 6).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1PracticeLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 6)
                                                            load.QtyHours = row.Semester1PracticeLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1PracticeLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 6;
                                                        subjectLoad.QtyHours = row.Semester1PracticeLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1LaboratoryLoad != null && row.Semester1LaboratoryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 7).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1LaboratoryLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 7)
                                                            load.QtyHours = row.Semester1LaboratoryLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1LaboratoryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 7;
                                                        subjectLoad.QtyHours = row.Semester1LaboratoryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1SeminarLoad != null && row.Semester1SeminarLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 8).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1SeminarLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 8)
                                                            load.QtyHours = row.Semester1SeminarLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1SeminarLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 8;
                                                        subjectLoad.QtyHours = row.Semester1SeminarLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1ProjectionLoad != null && row.Semester1ProjectionLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 9).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1ProjectionLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 9)
                                                            load.QtyHours = row.Semester1ProjectionLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1ProjectionLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 9;
                                                        subjectLoad.QtyHours = row.Semester1ProjectionLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1IndProjectLoad != null && row.Semester1IndProjectLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 10).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester1IndProjectLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 10)
                                                            load.QtyHours = row.Semester1IndProjectLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester1IndProjectLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 10;
                                                        subjectLoad.QtyHours = row.Semester1IndProjectLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                    }

                                    if (loads.Count == 0)
                                    {
                                        for (int i = 1; i <= 10; i++)
                                        {
                                            if (row.Semester1MaxLoad != null && row.Semester1MaxLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 1).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1MaxLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 1;
                                                        subjectLoad.QtyHours = row.Semester1MaxLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1IndependentLoad != null && row.Semester1IndependentLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 2).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1IndependentLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 2;
                                                        subjectLoad.QtyHours = row.Semester1IndependentLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1ConsultationLoad != null && row.Semester1ConsultationLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 3).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1ConsultationLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 3;
                                                        subjectLoad.QtyHours = row.Semester1ConsultationLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1NecessaryLoad != null && row.Semester1NecessaryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 4).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1NecessaryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 4;
                                                        subjectLoad.QtyHours = row.Semester1NecessaryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1LectureLoad != null && row.Semester1LectureLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 5).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1LectureLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 5;
                                                        subjectLoad.QtyHours = row.Semester1LectureLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1PracticeLoad != null && row.Semester1PracticeLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 6).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1PracticeLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 6;
                                                        subjectLoad.QtyHours = row.Semester1PracticeLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1LaboratoryLoad != null && row.Semester1LaboratoryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 7).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1LaboratoryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 7;
                                                        subjectLoad.QtyHours = row.Semester1LaboratoryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1SeminarLoad != null && row.Semester1SeminarLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 8).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1SeminarLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 8;
                                                        subjectLoad.QtyHours = row.Semester1SeminarLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1ProjectionLoad != null && row.Semester1ProjectionLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 9).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1ProjectionLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 9;
                                                        subjectLoad.QtyHours = row.Semester1ProjectionLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester1IndProjectLoad != null && row.Semester1IndProjectLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id && s.LoadTypeId == 10).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester1IndProjectLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = firstSemester.Id;
                                                        subjectLoad.LoadTypeId = 10;
                                                        subjectLoad.QtyHours = row.Semester1IndProjectLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                }
                                CollegeBaseEntities.GetContext().SaveChanges();

                                var secondSemester = plan.Where(s => s.Semester == 2).FirstOrDefault();
                                if (secondSemester != null)
                                {
                                    var loads = CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id).ToList();
                                    if (loads != null)
                                    {
                                        foreach (SubjectLoad load in loads)
                                        {
                                            if (row.Semester2MaxLoad != null && row.Semester2MaxLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 1).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2MaxLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 1)
                                                            load.QtyHours = row.Semester2MaxLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2MaxLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 1;
                                                        subjectLoad.QtyHours = row.Semester2MaxLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2IndependentLoad != null && row.Semester2IndependentLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 2).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2IndependentLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 2)
                                                            load.QtyHours = row.Semester2IndependentLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2IndependentLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 2;
                                                        subjectLoad.QtyHours = row.Semester2IndependentLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2ConsultationLoad != null && row.Semester2ConsultationLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 3).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2ConsultationLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 3)
                                                            load.QtyHours = row.Semester2ConsultationLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2ConsultationLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 3;
                                                        subjectLoad.QtyHours = row.Semester2ConsultationLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2NecessaryLoad != null && row.Semester2NecessaryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 4).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2NecessaryLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 4)
                                                            load.QtyHours = row.Semester2NecessaryLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2NecessaryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 4;
                                                        subjectLoad.QtyHours = row.Semester2NecessaryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2LectureLoad != null && row.Semester2LectureLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 5).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2LectureLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 5)
                                                            load.QtyHours = row.Semester2LectureLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2LectureLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 5;
                                                        subjectLoad.QtyHours = row.Semester2LectureLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2PracticeLoad != null && row.Semester2PracticeLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 6).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2PracticeLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 6)
                                                            load.QtyHours = row.Semester2PracticeLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2PracticeLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 6;
                                                        subjectLoad.QtyHours = row.Semester2PracticeLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2LaboratoryLoad != null && row.Semester2LaboratoryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 7).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2LaboratoryLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 7)
                                                            load.QtyHours = row.Semester2LaboratoryLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2LaboratoryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 7;
                                                        subjectLoad.QtyHours = row.Semester2LaboratoryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2SeminarLoad != null && row.Semester2SeminarLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 8).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2SeminarLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 8)
                                                            load.QtyHours = row.Semester2SeminarLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2SeminarLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 8;
                                                        subjectLoad.QtyHours = row.Semester2SeminarLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2ProjectionLoad != null && row.Semester2ProjectionLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 9).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2ProjectionLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 9)
                                                            load.QtyHours = row.Semester2ProjectionLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2ProjectionLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 9;
                                                        subjectLoad.QtyHours = row.Semester2ProjectionLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2IndProjectLoad != null && row.Semester2IndProjectLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 10).FirstOrDefault() != null)
                                                {
                                                    if (row.Semester2IndProjectLoad.Length > 0)
                                                    {
                                                        if (load.LoadTypeId == 10)
                                                            load.QtyHours = row.Semester2IndProjectLoad;
                                                    }
                                                    else
                                                    {
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Remove(load);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    if (row.Semester2IndProjectLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 10;
                                                        subjectLoad.QtyHours = row.Semester2IndProjectLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                    }


                                    if (loads.Count == 0)
                                    {
                                        for (int i = 1; i <= 10; i++)
                                        {
                                            if (row.Semester2MaxLoad != null && row.Semester2MaxLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 1).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2MaxLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 1;
                                                        subjectLoad.QtyHours = row.Semester2MaxLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2IndependentLoad != null && row.Semester2IndependentLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 2).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2IndependentLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 2;
                                                        subjectLoad.QtyHours = row.Semester2IndependentLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2ConsultationLoad != null && row.Semester2ConsultationLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 3).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2ConsultationLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 3;
                                                        subjectLoad.QtyHours = row.Semester2ConsultationLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2NecessaryLoad != null && row.Semester2NecessaryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 4).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2NecessaryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 4;
                                                        subjectLoad.QtyHours = row.Semester2NecessaryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2LectureLoad != null && row.Semester2LectureLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 5).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2LectureLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 5;
                                                        subjectLoad.QtyHours = row.Semester2LectureLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2PracticeLoad != null && row.Semester2PracticeLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 6).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2PracticeLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 6;
                                                        subjectLoad.QtyHours = row.Semester2PracticeLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2LaboratoryLoad != null && row.Semester2LaboratoryLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 7).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2LaboratoryLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 7;
                                                        subjectLoad.QtyHours = row.Semester2LaboratoryLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2SeminarLoad != null && row.Semester2SeminarLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 8).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2SeminarLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 8;
                                                        subjectLoad.QtyHours = row.Semester2SeminarLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2ProjectionLoad != null && row.Semester2ProjectionLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 9).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2ProjectionLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 9;
                                                        subjectLoad.QtyHours = row.Semester2ProjectionLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                            if (row.Semester2IndProjectLoad != null && row.Semester2IndProjectLoad.Length >= 0)
                                            {
                                                if (CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id && s.LoadTypeId == 10).FirstOrDefault() != null)
                                                {

                                                }
                                                else
                                                {
                                                    if (row.Semester2IndProjectLoad.Length > 0)
                                                    {
                                                        SubjectLoad subjectLoad = new SubjectLoad();
                                                        subjectLoad.SubjectSemesterId = secondSemester.Id;
                                                        subjectLoad.LoadTypeId = 10;
                                                        subjectLoad.QtyHours = row.Semester2IndProjectLoad;
                                                        CollegeBaseEntities.GetContext().SubjectLoads.Add(subjectLoad);
                                                        CollegeBaseEntities.GetContext().SaveChanges();
                                                    }
                                                }
                                                CollegeBaseEntities.GetContext().SaveChanges();
                                            }
                                        }
                                        CollegeBaseEntities.GetContext().SaveChanges();
                                    }
                                }
                                CollegeBaseEntities.GetContext().SaveChanges();
                            }
                        }
                    }
                    CollegeBaseEntities.GetContext().SaveChanges();
                }
                CollegeBaseEntities.GetContext().SaveChanges();
            }
            CollegeBaseEntities.GetContext().SaveChanges();
        }

        public static void DeleteRow(DataGrid dataGrid)
        {
            var selectedRow = (SubjectRow)dataGrid.SelectedItem;
            if (selectedRow != null)
            {
                int year = CollegeBaseEntities.GetContext().SubjectSpecialities.Where(s => s.Id == selectedRow.IdSubjectSpeciality).Select(s => s.StartYear).FirstOrDefault();
                if (dataGrid.SelectedItems.Count > 1)
                {
                    return;
                }
                if (MessageBox.Show("Вы точно хотите удалить данную дисциплину?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var selectedAttestations = CollegeBaseEntities.GetContext().Attestations.Where(a => a.SubjectSpecialityId == selectedRow.IdSubjectSpeciality).ToList();
                    if (selectedAttestations != null)
                    {
                        CollegeBaseEntities.GetContext().Attestations.RemoveRange(selectedAttestations);
                        CollegeBaseEntities.GetContext().SaveChanges();
                    }
                    var selectedLoads = CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemester.SubjectSpecialityId == selectedRow.IdSubjectSpeciality).ToList();
                    if (selectedLoads != null)
                    {
                        CollegeBaseEntities.GetContext().SubjectLoads.RemoveRange(selectedLoads);
                        CollegeBaseEntities.GetContext().SaveChanges();
                    }
                    var selectedSemester = CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpecialityId == selectedRow.IdSubjectSpeciality && s.Syllabu.Group.StartYear == year).ToList();
                    if (selectedSemester != null)
                    {
                        CollegeBaseEntities.GetContext().SubjectSemesters.RemoveRange(selectedSemester);
                        CollegeBaseEntities.GetContext().SaveChanges();
                        MessageBox.Show("Дисциплина удалена из учебного плана!");
                    }
                    /*var selectedSubject = CollegeBaseEntities.GetContext().SubjectSpecialities.Where(s => s.Id == selectedRow.IdSubjectSpeciality).FirstOrDefault();
                    if (selectedSubject != null)
                    {
                        CollegeBaseEntities.GetContext().SubjectSpecialities.Remove(selectedSubject);
                        CollegeBaseEntities.GetContext().SaveChanges();
                        
                    }*/
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать дисциплину для удаления!");
            }
        }
    }
}
