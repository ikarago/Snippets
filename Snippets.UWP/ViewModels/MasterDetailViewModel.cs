using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Snippets.UWP.Helpers;
using Snippets.UWP.Models;
using Snippets.UWP.Services;

namespace Snippets.UWP.ViewModels
{
    public class MasterDetailViewModel : Observable
    {
        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public MasterDetailViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetSampleModelDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
