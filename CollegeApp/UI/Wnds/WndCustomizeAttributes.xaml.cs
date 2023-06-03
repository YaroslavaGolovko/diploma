using CollegeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CollegeApp.UI.Wnds
{
    /// <summary>
    /// Логика взаимодействия для WndCustomizeAttributes.xaml
    /// </summary>
    public partial class WndCustomizeAttributes : Window
    {
        private bool visibilitySpecilaity;
        private bool visibilityQualification;
        private bool visibilityStartYear;
        private bool visibilityAcademicYear;
        private bool visibilityProfessor;
        public WndCustomizeAttributes()
        {
            InitializeComponent();
            visibilitySpecilaity = true;
            visibilityQualification = true;
            visibilityStartYear = true;
            visibilityAcademicYear = true;
            visibilityProfessor = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            DocumentRow.PrintRows(Classes.Control.DGridDocumentRow, Classes.Control.cmbSpecialityDocumentRow,
                Classes.Control.cmbQualificationDocumentRow, Classes.Control.cmbStartYearDocumentRow,
                Classes.Control.cmbAcademicYearDocumentRow, Classes.Control.cmbProfessorDocumentRow, visibilitySpecilaity,
                visibilityQualification, visibilityStartYear, visibilityAcademicYear,visibilityProfessor);
        }

        private void cbSpeciality_Checked(object sender, RoutedEventArgs e)
        {
            visibilitySpecilaity = true;
        }

        private void cbSpeciality_Unchecked(object sender, RoutedEventArgs e)
        {
            visibilitySpecilaity = false;
        }

        private void cbQualification_Checked(object sender, RoutedEventArgs e)
        {
            visibilityQualification = true;
        }

        private void cbQualification_Unchecked(object sender, RoutedEventArgs e)
        {
            visibilityQualification = false;
        }

        private void cbStartYear_Checked(object sender, RoutedEventArgs e)
        {
            visibilityStartYear = true;
        }

        private void cbStartYear_Unchecked(object sender, RoutedEventArgs e)
        {
            visibilityStartYear = false;
        }

        private void cbAcademicYear_Checked(object sender, RoutedEventArgs e)
        {
            visibilityAcademicYear = true;
        }

        private void cbAcademicYear_Unchecked(object sender, RoutedEventArgs e)
        {
            visibilityAcademicYear = false;
        }

        private void cbProfessor_Checked(object sender, RoutedEventArgs e)
        {
            visibilityProfessor = true;
        }

        private void cbProfessor_Unchecked(object sender, RoutedEventArgs e)
        {
            visibilityProfessor = false;
        }
    }
}
