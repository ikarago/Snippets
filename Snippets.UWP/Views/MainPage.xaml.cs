using System;

using Snippets.UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Snippets.UWP.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
