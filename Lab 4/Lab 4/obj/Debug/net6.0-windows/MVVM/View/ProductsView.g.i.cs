﻿#pragma checksum "..\..\..\..\..\MVVM\View\ProductsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A1CDF6E520BCC735A4CAEFEFCD82EEF1F214F05F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab_4;
using Lab_4.MVVM.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Lab_4.MVVM.View {
    
    
    /// <summary>
    /// ProductsView
    /// </summary>
    public partial class ProductsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 76 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton LightTheme;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton PinkTheme;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition Column1;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition Column2;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition Column3;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition Row1;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition Row2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Laba 4;component/mvvm/view/productsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LightTheme = ((System.Windows.Controls.RadioButton)(target));
            
            #line 76 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
            this.LightTheme.Checked += new System.Windows.RoutedEventHandler(this.LightTheme_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PinkTheme = ((System.Windows.Controls.RadioButton)(target));
            
            #line 77 "..\..\..\..\..\MVVM\View\ProductsView.xaml"
            this.PinkTheme.Checked += new System.Windows.RoutedEventHandler(this.PinkTheme_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.Column1 = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 5:
            this.Column2 = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 6:
            this.Column3 = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 7:
            this.Row1 = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 8:
            this.Row2 = ((System.Windows.Controls.RowDefinition)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

