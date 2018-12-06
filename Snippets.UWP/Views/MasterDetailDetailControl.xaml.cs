using System;
using Snippets.Core.ViewModels;
using Snippets.UWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Snippets.UWP.Views
{
    public sealed partial class MasterDetailDetailControl : UserControl
    {
        public SnippetViewModel MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SnippetViewModel; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SnippetViewModel), typeof(MasterDetailDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public MasterDetailDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MasterDetailDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
