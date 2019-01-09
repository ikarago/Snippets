using System;
using Snippets.Core.ViewModels;
using Snippets.UWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Snippets.UWP.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        public MasterDetailViewModel ViewModel { get; } = new MasterDetailViewModel();

        public MasterDetailPage()
        {
            InitializeComponent();
            //Loaded += MasterDetailPage_Loaded;
        }

        //private async void MasterDetailPage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        //}
    }
}
