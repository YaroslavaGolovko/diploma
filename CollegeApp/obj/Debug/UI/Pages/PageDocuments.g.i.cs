﻿#pragma checksum "..\..\..\..\UI\Pages\PageDocuments.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "59F19C108AA80E568F51E66534BB034F4F6C0EA6D9B835B17EDC5A261CCF8068"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CollegeApp.UI.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CollegeApp.UI.Pages {
    
    
    /// <summary>
    /// PageDocuments
    /// </summary>
    public partial class PageDocuments : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSpecialities;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbQualifications;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbStartYear;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbAcademicYear;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbProfessors;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGridDocuments;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRow;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteRow;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\UI\Pages\PageDocuments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CollegeApp;component/ui/pages/pagedocuments.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cmbSpecialities = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.cmbSpecialities.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSpecialities_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbQualifications = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.cmbQualifications.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbQualifications_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbStartYear = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.cmbStartYear.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbStartYear_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbAcademicYear = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.cmbAcademicYear.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbAcademicYear_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbProfessors = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.cmbProfessors.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbProfessors_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DGridDocuments = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.btnAddRow = ((System.Windows.Controls.Button)(target));
            
            #line 238 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.btnAddRow.Click += new System.Windows.RoutedEventHandler(this.btnAddRow_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnDeleteRow = ((System.Windows.Controls.Button)(target));
            
            #line 239 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.btnDeleteRow.Click += new System.Windows.RoutedEventHandler(this.btnDeleteRow_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 240 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 80 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbWPElectronic_Checked);
            
            #line default
            #line hidden
            
            #line 80 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbWPElectronic_Unchecked);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 118 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbWPTypewriter_Checked);
            
            #line default
            #line hidden
            
            #line 118 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbWPTypewriter_Unchecked);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 156 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbCTPElectronic_Checked);
            
            #line default
            #line hidden
            
            #line 156 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbCTPElectronic_Unchecked);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 194 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbCTPTypewriter_Checked);
            
            #line default
            #line hidden
            
            #line 194 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbCTPTypewriter_Unchecked);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 231 "..\..\..\..\UI\Pages\PageDocuments.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbNote_TextChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

