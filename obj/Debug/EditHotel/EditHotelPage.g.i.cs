﻿#pragma checksum "..\..\..\EditHotel\EditHotelPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C8508CEC47CEC7D15B766BB7C81151220A81634482C20ED89D7A556F454EF7D2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hotelin_Desktop.EditHotel;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Hotelin_Desktop.EditHotel {
    
    
    /// <summary>
    /// EditHotelPage
    /// </summary>
    public partial class EditHotelPage : Velacro.UIElements.Basic.MyPage, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\EditHotel\EditHotelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nama_hotel_txt;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\EditHotel\EditHotelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lokasi_hotel_txt;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\EditHotel\EditHotelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox deskripsi_hotel_txt;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\EditHotel\EditHotelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label file_name_lbl;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\EditHotel\EditHotelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pilih_gambar_btn;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\EditHotel\EditHotelPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button simpan_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/Hotelin-Desktop;component/edithotel/edithotelpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditHotel\EditHotelPage.xaml"
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
            this.lokasi_hotel_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.deskripsi_hotel_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.file_name_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.pilih_gambar_btn = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.simpan_btn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

