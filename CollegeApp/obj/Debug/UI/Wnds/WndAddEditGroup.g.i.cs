﻿#pragma checksum "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ED2C2B6BE38B431EB197BC50BAD6E5183FF0E747A7EA583396292439E91E127E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CollegeApp.UI;
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


namespace CollegeApp.UI {
    
    
    /// <summary>
    /// WndAddEditGroup
    /// </summary>
    public partial class WndAddEditGroup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblName;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNumber;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSpesialities;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbQualifications;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbStartYear;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
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
            System.Uri resourceLocater = new System.Uri("/CollegeApp;component/ui/wnds/wndaddeditgroup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
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
            this.tbNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
            this.tbNumber.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbNumber_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbSpesialities = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
            this.cmbSpesialities.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSpesialities_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbQualifications = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
            this.cmbQualifications.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbQualifications_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbStartYear = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
            this.tbStartYear.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbStartYear_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\UI\Wnds\WndAddEditGroup.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

