﻿#pragma checksum "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "19E5C2BAF576A46071599F34AA91EFE0715ED6D12D9E7404D2517944A36AC3E0"
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
using WSChina2020AppComp03.Pages.Coordinator;


namespace WSChina2020AppComp03.Pages.Coordinator {
    
    
    /// <summary>
    /// SponsorshipViewPage
    /// </summary>
    public partial class SponsorshipViewPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbEvent;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbSponsor;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbCompetition;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSearch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExport;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgSponsorship;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp03;component/pages/coordinator/sponsorshipviewpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
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
            this.TbSponsor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CbCompetition = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.BtnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
            this.BtnSearch.Click += new System.Windows.RoutedEventHandler(this.BtnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnExport = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Pages\Coordinator\SponsorshipViewPage.xaml"
            this.BtnExport.Click += new System.Windows.RoutedEventHandler(this.BtnExport_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DgSponsorship = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

