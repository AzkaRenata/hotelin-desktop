// Updated by XamlIntelliSenseFileGenerator 30/12/2020 17:12:34
#pragma checksum "..\..\..\EditKamar\EditKamarPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C9991E040ED0BED4C48DA30B51ECEBD8FEEC7EF90A8753F338C3C296AB754A10"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hotelin_Desktop.EditKamar;
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


namespace Hotelin_Desktop.EditKamar
{


    /// <summary>
    /// EditKamarPage
    /// </summary>
    public partial class EditKamarPage : Velacro.UIElements.Basic.MyPage, System.Windows.Markup.IComponentConnector
    {


#line 30 "..\..\..\EditKamar\EditKamarPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tipe_kamar_txt;

#line default
#line hidden


#line 47 "..\..\..\EditKamar\EditKamarPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tipe_kasur_txt;

#line default
#line hidden


#line 64 "..\..\..\EditKamar\EditKamarPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox harga_kamar_txt;

#line default
#line hidden


#line 81 "..\..\..\EditKamar\EditKamarPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kapasitas_tamu_txt;

#line default
#line hidden


#line 126 "..\..\..\EditKamar\EditKamarPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label file_name_lbl;

#line default
#line hidden


#line 137 "..\..\..\EditKamar\EditKamarPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit_kamar_btn;

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
            System.Uri resourceLocater = new System.Uri("/Hotelin-Desktop;component/editkamar/editkamarpage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\EditKamar\EditKamarPage.xaml"
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
                    this.tipe_kamar_txt = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.tipe_kasur_txt = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.harga_kamar_txt = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.kapasitas_tamu_txt = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.file_name_lbl = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.edit_kamar_btn = ((System.Windows.Controls.Button)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox kode_kamar_txt;
        internal System.Windows.Controls.TextBox jumlah_kasur_txt;
        internal System.Windows.Controls.TextBox fasilitas_kamar_txt;
        internal System.Windows.Controls.Button pilih_gambar_btn;
    }
}

