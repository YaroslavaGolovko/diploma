﻿#pragma checksum "..\..\..\..\UI\Windows\WndAddEditLoad.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "86F6655225DA064796E8579886739A10B9DAAC00EE32CAAD91655B065B27A4F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CollegeApp.UI.Windows;
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


namespace CollegeApp.UI.Windows {
    
    
    /// <summary>
    /// WndAddEditLoad
    /// </summary>
    public partial class WndAddEditLoad : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblName;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblSubject;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbProfessors;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddProfessor;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/CollegeApp;component/ui/windows/wndaddeditload.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
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
            this.tblName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tblSubject = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.cmbProfessors = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
            this.cmbProfessors.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbProfessors_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAddProfessor = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
            this.btnAddProfessor.Click += new System.Windows.RoutedEventHandler(this.btnAddProfessor_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\UI\Windows\WndAddEditLoad.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

