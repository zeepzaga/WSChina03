﻿#pragma checksum "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "30DEA190DBBA348FFD9276AE31045070CB133209C1C86A1E9367A41F59D7AED6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using WSChina2020AppComp03.Pages.Admin;


namespace WSChina2020AppComp03.Pages.Admin {
    
    
    /// <summary>
    /// CompetitionSkillsPage
    /// </summary>
    public partial class CompetitionSkillsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbEvent;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSearch;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblTotalSkills;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser WebMain;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddSkills;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp03;component/pages/admin/competitionskillspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
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
            this.CbEvent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.BtnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
            this.BtnSearch.Click += new System.Windows.RoutedEventHandler(this.BtnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TblTotalSkills = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.WebMain = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 5:
            this.BtnAddSkills = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Pages\Admin\CompetitionSkillsPage.xaml"
            this.BtnAddSkills.Click += new System.Windows.RoutedEventHandler(this.BtnAddSkills_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
