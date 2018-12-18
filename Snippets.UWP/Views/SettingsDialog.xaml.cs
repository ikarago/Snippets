using Snippets.UWP.Helpers;
using Snippets.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Snippets.UWP.Views
{
    public sealed partial class SettingsDialog : ContentDialog
    {
        public SettingsViewModel ViewModel { get; } = Singleton<SettingsViewModel>.Instance;


        public SettingsDialog()
        {
            RequestedTheme = (Window.Current.Content as FrameworkElement).RequestedTheme;
            this.InitializeComponent();
        }

        // Commands
        private ICommand _closeDialogCommand;
        public ICommand CloseDialogCommand
        {
            get
            {
                if (_closeDialogCommand == null)
                {
                    _closeDialogCommand = new RelayCommand(
                        () =>
                        {
                            Hide();
                        });
                }
                return _closeDialogCommand;
            }
        }
    }
}
