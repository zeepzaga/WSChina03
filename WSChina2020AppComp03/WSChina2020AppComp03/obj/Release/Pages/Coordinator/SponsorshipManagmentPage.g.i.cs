// Updated by XamlIntelliSenseFileGenerator 29.05.2020 19:07:21
#pragma checksum "..\..\..\..\Pages\Coordinator\SponsorshipManagmentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BDCD1E0D5E388914C77E37D4F3D9A406F672B07EDA7E208A0D6AB26A9D3B5A8F"
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
using WSChina2020AppComp03.Pages.Coordinator;


namespace WSChina2020AppComp03.Pages.Coordinator
{


    /// <summary>
    /// SponsorshipManagmentPage
    /// </summary>
    public partial class SponsorshipManagmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 17 "..\..\..\..\Pages\Coordinator\SponsorshipManagmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnStatistics;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp03;component/pages/coordinator/sponsorshipmanagmentpage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Pages\Coordinator\SponsorshipManagmentPage.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.BtnStatistics = ((System.Windows.Controls.Button)(target));

#line 17 "..\..\..\..\Pages\Coordinator\SponsorshipManagmentPage.xaml"
                    this.BtnStatistics.Click += new System.Windows.RoutedEventHandler(this.BtnStatistics_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button BtnView;
        internal System.Windows.Controls.Button BtnChart;
    }
}

