﻿#pragma checksum "..\..\..\..\View\AddModelView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E99E0CE9F4B1A091A80832429ED4E2178D30B458"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
using simple_database.View;


namespace simple_database.View {
    
    
    /// <summary>
    /// AddModelView
    /// </summary>
    public partial class AddModelView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Caption;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameBox;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionBox;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CategoryBox;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InvNumberBox;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DataBox;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ConditionBox;
        
        #line default
        #line hidden
        
        
        #line 264 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 301 "..\..\..\..\View\AddModelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InvManager;component/view/addmodelview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\AddModelView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\..\View\AddModelView.xaml"
            ((simple_database.View.AddModelView)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.AddView_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Caption = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.NameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DescriptionBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CategoryBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.InvNumberBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DataBox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.ConditionBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 253 "..\..\..\..\View\AddModelView.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 290 "..\..\..\..\View\AddModelView.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
