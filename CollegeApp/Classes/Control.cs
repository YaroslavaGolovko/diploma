using CollegeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CollegeApp.Classes
{
    public class Control
    {
        public static Frame _currentFrame { get; set; }
        public static User _currentUser { get; set; }
        public static Syllabu _currentPlan { get; set; }
        public static DataGrid DGridSubjects { get; set; }

        public static DataGrid DGridDocumentRow { get; set; }
        public static ComboBox cmbSpecialityDocumentRow { get; set; }
        public static ComboBox cmbQualificationDocumentRow { get; set; }
        public static ComboBox cmbAcademicYearDocumentRow { get; set; }
        public static ComboBox cmbStartYearDocumentRow { get; set; }
        public static ComboBox cmbProfessorDocumentRow { get; set; }

        public static bool CheckEnter(string login, string password)
        {
            _currentUser = CollegeBaseEntities.GetContext().Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            if (_currentUser != null)
                return true;

            return false;
        }
    }
}
