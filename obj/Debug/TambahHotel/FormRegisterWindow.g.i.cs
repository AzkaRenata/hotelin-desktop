﻿#pragma checksum "..\..\..\TambahHotel\FormRegisterWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "288C9097DC9EF155A5634A56F891B452267A765F8CE5ED6637E665DDE0956F47"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hotelin_Desktop.Register;
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


namespace Hotelin_Desktop.Register {
    
    
    /// <summary>
    /// FormRegisterWindow
    /// </summary>
    public partial class FormRegisterWindow : Velacro.UIElements.Basic.MyWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nama_hotel_txt;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lokasi_txt;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fasilitas_txt;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox harga_txt;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rating_txt;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox deskripsi_txt;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label file_name_lbl;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button register_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/Hotelin-Desktop;component/tambahhotel/formregisterwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
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
            this.nama_hotel_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.lokasi_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.fasilitas_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.harga_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.rating_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.deskripsi_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 138 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.rectangle_drop);
            
            #line default
            #line hidden
            return;
            case 8:
            this.file_name_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.register_btn = ((System.Windows.Controls.Button)(target));
            
            #line 183 "..\..\..\TambahHotel\FormRegisterWindow.xaml"
            this.register_btn.Click += new System.Windows.RoutedEventHandler(this.register_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
