﻿#pragma checksum "..\..\wndItems.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C1834205046EC5F3FAAE51513AE29123561DEE326B655C5FEE4D11BE05EBD895"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GroupProject;
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


namespace GroupProject {
    
    
    /// <summary>
    /// wndItems
    /// </summary>
    public partial class wndItems : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid itemsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn itemCodeColumn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn itemDescColumn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn itemCostColumn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox invoiceTotalDrop;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox invoiceNumDrop;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/GroupProject;component/wnditems.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\wndItems.xaml"
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
            this.itemsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\wndItems.xaml"
            this.itemsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.itemsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.itemCodeColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.itemDescColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.itemCostColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.invoiceTotalDrop = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.invoiceNumDrop = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\wndItems.xaml"
            this.invoiceNumDrop.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.invoiceNumDrop_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\wndItems.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.searchButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\wndItems.xaml"
            this.clearButton.Click += new System.Windows.RoutedEventHandler(this.clearButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\wndItems.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.editButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\wndItems.xaml"
            this.editButton.Click += new System.Windows.RoutedEventHandler(this.editButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\wndItems.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

