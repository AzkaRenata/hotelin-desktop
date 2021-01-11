﻿#pragma checksum "..\..\..\Dashboard\DashboardWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99E24A38005D543AE6D19287A2589E1F849878414427E2F5690013002B563C1E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hotelin_Desktop.Dashboard;
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
using Velacro.UIElements.Basic;


namespace Hotelin_Desktop.Dashboard {
    
    
    /// <summary>
    /// DashboardWindow
    /// </summary>
    public partial class DashboardWindow : Velacro.UIElements.Basic.MyWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Hotelin_Desktop.Dashboard.DashboardWindow dashboardWindow;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button profileButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button detailButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pemesananButton;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pengunjungButton;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pembatalanButton;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button aboutUsButton;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutButton;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Dashboard\DashboardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame appFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/Hotelin-Desktop;component/dashboard/dashboardwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dashboard\DashboardWindow.xaml"
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
            this.dashboardWindow = ((Hotelin_Desktop.Dashboard.DashboardWindow)(target));
            return;
            case 2:
            this.profileButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Dashboard\DashboardWindow.xaml"
            this.profileButton.Click += new System.Windows.RoutedEventHandler(this.profileButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.detailButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\Dashboard\DashboardWindow.xaml"
            this.detailButton.Click += new System.Windows.RoutedEventHandler(this.detailButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pemesananButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\Dashboard\DashboardWindow.xaml"
            this.pemesananButton.Click += new System.Windows.RoutedEventHandler(this.pemesananButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pengunjungButton = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Dashboard\DashboardWindow.xaml"
            this.pengunjungButton.Click += new System.Windows.RoutedEventHandler(this.pengunjungButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pembatalanButton = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\Dashboard\DashboardWindow.xaml"
            this.pembatalanButton.Click += new System.Windows.RoutedEventHandler(this.pembatalanButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.aboutUsButton = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\Dashboard\DashboardWindow.xaml"
            this.aboutUsButton.Click += new System.Windows.RoutedEventHandler(this.aboutUsButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.logoutButton = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\Dashboard\DashboardWindow.xaml"
            this.logoutButton.Click += new System.Windows.RoutedEventHandler(this.logoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.appFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

