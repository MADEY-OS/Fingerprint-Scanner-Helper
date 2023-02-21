﻿#pragma checksum "..\..\..\..\..\Components\Windows\SetupWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0A6FE797D390BE10E8177B5316094AE851563091"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FingerprintScannerHelper.Components.Windows;
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


namespace FingerprintScannerHelper.Components.Windows {
    
    
    /// <summary>
    /// SetupWindow
    /// </summary>
    public partial class SetupWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSrc;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSrc;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDest;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDest;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbArduinoPort;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbArduinoBaud;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FingerprintScannerHelper;component/components/windows/setupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbSrc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnSrc = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
            this.btnSrc.Click += new System.Windows.RoutedEventHandler(this.BtnSrc_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbDest = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnDest = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
            this.btnDest.Click += new System.Windows.RoutedEventHandler(this.BtnDest_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbArduinoPort = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbArduinoBaud = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\..\Components\Windows\SetupWindow.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.BtnConfirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

