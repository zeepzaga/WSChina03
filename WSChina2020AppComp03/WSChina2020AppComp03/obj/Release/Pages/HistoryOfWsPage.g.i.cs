﻿#pragma checksum "..\..\..\Pages\HistoryOfWsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C815516867F36116367DD25DB868137A418AD83BC119B55329D7C86F591E5824"
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
using WSChina2020AppComp03.Pages;


namespace WSChina2020AppComp03.Pages {
    
    
    /// <summary>
    /// HistoryOfWsPage
    /// </summary>
    public partial class HistoryOfWsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Pages\HistoryOfWsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageAlbert;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\HistoryOfWsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageFirst;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\HistoryOfWsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageBoard;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\HistoryOfWsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Scroll;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\HistoryOfWsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TblDescription;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp03;component/pages/historyofwspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\HistoryOfWsPage.xaml"
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
            
            #line 24 "..\..\..\Pages\HistoryOfWsPage.xaml"
            ((System.Windows.Shapes.Ellipse)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Ellipse_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ImageAlbert = ((System.Windows.Controls.Image)(target));
            
            #line 29 "..\..\..\Pages\HistoryOfWsPage.xaml"
            this.ImageAlbert.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ImageAlbert_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ImageFirst = ((System.Windows.Controls.Image)(target));
            
            #line 31 "..\..\..\Pages\HistoryOfWsPage.xaml"
            this.ImageFirst.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ImageAlbert_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ImageBoard = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\Pages\HistoryOfWsPage.xaml"
            this.ImageBoard.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ImageAlbert_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Scroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.TblDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

