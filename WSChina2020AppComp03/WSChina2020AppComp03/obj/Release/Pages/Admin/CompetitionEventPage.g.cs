﻿#pragma checksum "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AE02F5E21B904571A2FDFE6B1368464E53ACB28BDD824C7D202AE89B55B60070"
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
    /// CompetitionEventPage
    /// </summary>
    public partial class CompetitionEventPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddEvent;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbSearch;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgEvent;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRegistration;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp03;component/pages/admin/competitioneventpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
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
            this.BtnAddEvent = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
            this.BtnAddEvent.Click += new System.Windows.RoutedEventHandler(this.BtnAddEvent_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
            this.TbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DgEvent = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
            this.DgEvent.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgEvent_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnRegistration = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Pages\Admin\CompetitionEventPage.xaml"
            this.BtnRegistration.Click += new System.Windows.RoutedEventHandler(this.BtnRegistration_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

