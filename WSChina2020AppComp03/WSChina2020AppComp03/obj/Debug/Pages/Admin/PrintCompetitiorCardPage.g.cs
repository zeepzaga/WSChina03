﻿#pragma checksum "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72987E9B565CA2CB36F958AF3D5E4EA778B983F90034E9D0BCE80DD6C5112993"
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
    /// PrintCompetitiorCardPage
    /// </summary>
    public partial class PrintCompetitiorCardPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridPrint;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgPhoto;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblSkill;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblCompNumber;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReturn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrint;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp03;component/pages/admin/printcompetitiorcardpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
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
            this.GridPrint = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ImgPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.TblName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TblSkill = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TblCompNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.BtnReturn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
            this.BtnReturn.Click += new System.Windows.RoutedEventHandler(this.BtnReturn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnPrint = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Pages\Admin\PrintCompetitiorCardPage.xaml"
            this.BtnPrint.Click += new System.Windows.RoutedEventHandler(this.BtnPrint_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
