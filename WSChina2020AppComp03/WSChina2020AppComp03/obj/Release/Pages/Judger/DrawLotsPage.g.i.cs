﻿#pragma checksum "..\..\..\..\Pages\Judger\DrawLotsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A7BF84FA359BA107143F4EEE8BAE907E2AA45C5EF066DDF9FC2751C54693AA45"
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
using WSChina2020AppComp03.Pages.Judger;


namespace WSChina2020AppComp03.Pages.Judger {
    
    
    /// <summary>
    /// DrawLotsPage
    /// </summary>
    public partial class DrawLotsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Pages\Judger\DrawLotsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblEvent;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Pages\Judger\DrawLotsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblSkill;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\Judger\DrawLotsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblTotal;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\Judger\DrawLotsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgCompetitiors;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\Judger\DrawLotsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDrawLots;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp03;component/pages/judger/drawlotspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Judger\DrawLotsPage.xaml"
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
            this.TblEvent = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TblSkill = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TblTotal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.DgCompetitiors = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.BtnDrawLots = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Pages\Judger\DrawLotsPage.xaml"
            this.BtnDrawLots.Click += new System.Windows.RoutedEventHandler(this.BtnDrawLots_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

