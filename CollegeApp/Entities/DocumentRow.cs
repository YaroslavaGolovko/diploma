using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using word = Microsoft.Office.Interop.Word;

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

        public static List<DocumentRow> GetRows(List<SubjectProfessor> documents)
        {
            var rows = new List<DocumentRow>();
            foreach (var document in documents)
            {
                DocumentRow row = new DocumentRow();
                row.Id = document.Id;
                row.SubjectSemesterId = document.SubjectSemesterId;
                var _currentDocument = document.Documents.FirstOrDefault();
                if (_currentDocument != null)
                {
                    row.DocumentId = _currentDocument.Id;
                    row.ProfessorFullName = document.Professor.FullName;
                    row.ProfessorId = document.ProfessorId;
                    row.SubjectName = document.SubjectSemester.SubjectSpeciality.Subject.Name;
                    row.Note = _currentDocument.Note;
                    row.Syllabus = document.SubjectSemester.Syllabu;
                    row.SpecialityId = row.Syllabus.Group.SpecialityId;
                    row.Qualification = row.Syllabus.Group.Qualification.Name;
                    row.AcademicYear = row.Syllabus.AcademicYear;
                    row.StartYear = row.Syllabus.Group.StartYear;
                    row.Semester = document.SubjectSemester.Semester;
                    int cours = Int32.Parse(row.AcademicYear.Substring(0, 4)) - row.StartYear;
                    switch (cours)
                    {
                        case 0:
                            if (document.SubjectSemester.Semester == 1)
                                row.SemesterVisible = 1;
                            if (document.SubjectSemester.Semester == 2)
                                row.SemesterVisible = 2;
                            break;

                        case 1:
                            if (document.SubjectSemester.Semester == 1)
                                row.SemesterVisible = 3;
                            if (document.SubjectSemester.Semester == 2)
                                row.SemesterVisible = 4;
                            break;

                        case 2:
                            if (document.SubjectSemester.Semester == 1)
                                row.SemesterVisible = 5;
                            if (document.SubjectSemester.Semester == 2)
                                row.SemesterVisible = 6;
                            break;

                        case 3:
                            if (document.SubjectSemester.Semester == 1)
                                row.SemesterVisible = 7;
                            if (document.SubjectSemester.Semester == 2)
                                row.SemesterVisible = 8;
                            break;
                    }
                    row.WorkProgramElectronicIsExist = false;
                    row.WorkProgramTypewriterIsExist = false;
                    row.CalendarThematicPlanElectronicIsExist = false;
                    row.CalendarThematicPlanTypewriterIsExist = false;
                    var _currentWorkProgramElectronic = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 1).FirstOrDefault();
                    if (_currentWorkProgramElectronic != null)
                    {
                        row.WorkProgramElectronicIsExist = true;
                        row.WorkProgramElectronicId = _currentWorkProgramElectronic.Id;
                        row.WorkProgramElectronicDate = _currentWorkProgramElectronic.Date;
                    }
                    var _currentWorkProgramTypewriter = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 2).FirstOrDefault();
                    if (_currentWorkProgramTypewriter != null)
                    {
                        row.WorkProgramTypewriterIsExist = true;
                        row.WorkProgramTypewriterId = _currentWorkProgramTypewriter.Id;
                        row.WorkProgramTypewriterDate = _currentWorkProgramTypewriter.Date;
                    }
                    var _currentCalendarThematicPlanElectronic = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 3).FirstOrDefault();
                    if (_currentCalendarThematicPlanElectronic != null)
                    {
                        row.CalendarThematicPlanElectronicIsExist = true;
                        row.CalendarThematicPlanElectronicId = _currentCalendarThematicPlanElectronic.Id;
                        row.CalendarThematicPlanElectronicDate = _currentCalendarThematicPlanElectronic.Date;
                    }
                    var _currentCalendarThematicPlanTypewriter = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 4).FirstOrDefault();
                    if (_currentCalendarThematicPlanTypewriter != null)
                    {
                        row.CalendarThematicPlanTypewriterIsExist = true;
                        row.CalendarThematicPlanTypewriterId = _currentCalendarThematicPlanTypewriter.Id;
                        row.CalendarThematicPlanTypewriterDate = _currentCalendarThematicPlanTypewriter.Date;
                    }
                    if (rows.Where(r => r.SubjectSemesterId == row.SubjectSemesterId && r.ProfessorId == row.ProfessorId || (r.ProfessorId == row.ProfessorId && r.SpecialityId == row.SpecialityId && r.Qualification == row.Qualification && r.StartYear == row.StartYear && r.AcademicYear == r.AcademicYear && r.Semester == row.Semester && r.SemesterVisible == row.SemesterVisible && r.SubjectName == row.SubjectName)).FirstOrDefault() == null)
                    {
                        rows.Add(row);
                    }
                }
            }
            return rows;
        }

        public static void SaveRows(DataGrid dataGrid)
        {
            List<DocumentRow> rows = dataGrid.ItemsSource as List<DocumentRow>;
            foreach (var row in rows)
            {
                var _currentSubjectProfessors = CollegeBaseEntities.GetContext().Documents.Where(s => s.SubjectProfessor.ProfessorId == row.ProfessorId && s.SubjectProfessor.SubjectSemester.Semester == row.Semester && s.SubjectProfessor.SubjectSemester.Syllabu.Group.SpecialityId == row.SpecialityId && s.SubjectProfessor.SubjectSemester.Syllabu.Group.Qualification.Name == row.Qualification && s.SubjectProfessor.SubjectSemester.Syllabu.AcademicYear == row.AcademicYear && s.SubjectProfessor.SubjectSemester.Syllabu.Group.StartYear == row.StartYear).ToList();
                foreach (var item in _currentSubjectProfessors)
                {
                    if (row.WorkProgramElectronicIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 1).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 1;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                        else
                        {
                            supply.Date = row.WorkProgramElectronicDate;
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 1).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.WorkProgramTypewriterIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 2).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 2;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                        else
                        {
                            supply.Date = row.WorkProgramTypewriterDate;
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 2).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.CalendarThematicPlanElectronicIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 3).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 3;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                        else
                        {
                            supply.Date = row.CalendarThematicPlanElectronicDate;
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 3).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.CalendarThematicPlanTypewriterIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 4).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 4;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                        else
                        {
                            supply.Date = row.CalendarThematicPlanTypewriterDate;
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 4).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.Note != null)
                    {
                        item.Note = row.Note;
                    }
                    else
                    {
                        item.Note = null;
                    }
                    CollegeBaseEntities.GetContext().SaveChanges();
                }
                CollegeBaseEntities.GetContext().SaveChanges();
            }
            CollegeBaseEntities.GetContext().SaveChanges();
        }

        public static void PrintRows(DataGrid dataGrid, ComboBox cmbSpecialities, ComboBox cmbQualifications, 
            ComboBox cmbStartYear, ComboBox cmbAcademicYear, ComboBox cmbProfessors)
        {
            try
            {
                List<DocumentRow> rows = dataGrid.ItemsSource as List<DocumentRow>;
                var application = new word.Application();
                word.Document document = application.Documents.Add();

                if (cmbSpecialities.SelectedItem != null)
                {
                    Speciality speciality = cmbSpecialities.SelectedItem as Speciality;
                    string text = speciality.Id;
                    word.Paragraph specialityParagraph = document.Paragraphs.Add();
                    specialityParagraph.LeftIndent = -30;
                    word.Range specialityRange = specialityParagraph.Range;
                    specialityRange.Text = "Специальность: " + text;
                    specialityRange.InsertParagraphAfter();
                }

                if (cmbQualifications.SelectedItem != null)
                {
                    Qualification qualification = cmbQualifications.SelectedItem as Qualification;
                    string text = qualification.Name;
                    word.Paragraph qualificationParagraph = document.Paragraphs.Add();
                    qualificationParagraph.LeftIndent = -30;
                    word.Range qualificationRange = qualificationParagraph.Range;
                    qualificationRange.Text = "Квалификация: " + text;
                    qualificationRange.InsertParagraphAfter();
                }

                if (cmbStartYear.SelectedItem != null)
                {
                    TextBlock startYear = cmbStartYear.SelectedItem as TextBlock;
                    string text = startYear.Text;
                    word.Paragraph startYearParagraph = document.Paragraphs.Add();
                    startYearParagraph.LeftIndent = -30;
                    word.Range startYearRange = startYearParagraph.Range;
                    startYearRange.Text = "Год набора: " + text;
                    startYearRange.InsertParagraphAfter();
                }

                if (cmbAcademicYear.SelectedItem != null)
                {
                    TextBlock academicYear = cmbAcademicYear.SelectedItem as TextBlock;
                    string text = academicYear.Text;
                    word.Paragraph academicYearParagraph = document.Paragraphs.Add();
                    academicYearParagraph.LeftIndent = -30;
                    word.Range academicYearRange = academicYearParagraph.Range;
                    academicYearRange.Text = "Учебный год: " + text;

                    academicYearRange.InsertParagraphAfter();
                }

                if (cmbProfessors.SelectedItem != null)
                {
                    if (cmbProfessors.SelectedIndex > 0)
                    {
                        Professor professor = cmbProfessors.SelectedItem as Professor;
                        string text = professor.FullName;
                        word.Paragraph professorParagraph = document.Paragraphs.Add();
                        professorParagraph.LeftIndent = -30;
                        word.Range professorRange = professorParagraph.Range;
                        professorRange.Text = "Преподаватель: " + text;
                        professorRange.InsertParagraphAfter();
                    }
                }

                word.Paragraph tableParagraph = document.Paragraphs.Add();
                word.Range tableRange = tableParagraph.Range;
                word.Table table = document.Tables.Add(tableRange, rows.Count() + 1, 6);
                table.Rows.LeftIndent = -30;
                table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                table.Range.Cells.VerticalAlignment = word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                word.Range cellRange;
                cellRange = table.Cell(1, 1).Range;
                cellRange.Text = "Дисциплина, преподаватель, учебный план";
                cellRange = table.Cell(1, 2).Range;
                cellRange.Text = "РП (эл. вид)";
                cellRange = table.Cell(1, 3).Range;
                cellRange.Text = "РП (печатный вид)";
                cellRange = table.Cell(1, 4).Range;
                cellRange.Text = "КТП (эл. вид)";
                cellRange = table.Cell(1, 5).Range;
                cellRange.Text = "КТП (печатный вид)";
                cellRange = table.Cell(1, 6).Range;
                cellRange.Text = "Примечания";
                table.Rows[1].Range.Bold = 1;
                table.Rows[1].Range.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                table.Columns[1].SetWidth(application.Application.CentimetersToPoints(4f), word.WdRulerStyle.wdAdjustNone);
                table.Columns[6].SetWidth(application.Application.CentimetersToPoints(3f), word.WdRulerStyle.wdAdjustNone);
                for (int i = 0; i < rows.Count(); i++)
                {
                    var row = rows[i];

                    cellRange = table.Cell(i + 2, 1).Range;
                    cellRange.Text = "Дисциплина: " + row.SubjectName + "\r\n" + "Преподаватель: " + row.ProfessorFullName + 
                        "\r\n" + "Специальность: " + row.SpecialityId + "\r\n" + "Квалификация: " + row.Qualification + "\r\n" + 
                        "Учебный год: " + row.AcademicYear + "\r\n" + "Год набора: " + row.StartYear + "\r\n" + "Семестр: " + row.SemesterVisible;
                    cellRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = table.Cell(i + 2, 2).Range;
                    if (row.WorkProgramElectronicIsExist == true)
                    {
                        cellRange.Text = "Сдано " + row.WorkProgramElectronicDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        cellRange.Text = "Не сдано";
                    }
                    cellRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = table.Cell(i + 2, 3).Range;
                    if (row.WorkProgramTypewriterIsExist == true)
                    {
                        cellRange.Text = "Сдано " + row.WorkProgramTypewriterDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        cellRange.Text = "Не сдано";
                    }
                    cellRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = table.Cell(i + 2, 4).Range;
                    if (row.CalendarThematicPlanElectronicIsExist == true)
                    {
                        cellRange.Text = "Сдано " + row.CalendarThematicPlanElectronicDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        cellRange.Text = "Не сдано";
                    }
                    cellRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = table.Cell(i + 2, 5).Range;
                    if (row.CalendarThematicPlanTypewriterIsExist == true)
                    {
                        cellRange.Text = "Сдано " + row.WorkProgramTypewriterDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        cellRange.Text = "Не сдано";
                    }
                    cellRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = table.Cell(i + 2, 6).Range;
                    cellRange.Text = row.Note;
                    cellRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                document.Words.Last.InsertBreak(word.WdBreakType.wdPageBreak);
                application.Visible = true;
                document.Save();
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == true)
                {
                    pd.PrintVisual(application as Visual, "printing as visual");
                    pd.PrintDocument((((IDocumentPaginatorSource)application).DocumentPaginator), "printing as paginator");
                }
            }
            catch
            {
                MessageBox.Show("При формировании документа возникли неполадки. Повторите попытку позже.", 
                    "Ошибка загрузки!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
