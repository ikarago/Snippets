using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Snippets.UWP.Helpers
{
    public class DateTimeToFriendlyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            
            try
            {
                // Putting it in a normal DateTime object so we can actually do stuff with it
                DateTime date = (DateTime)value;

                // #TODO: Get the strings (Today, Yesterday) from the Resourcefile
                if (date.Date == DateTime.Today.Date)
                {
                    // #TODO: Add Just Now
                    return (ResourceExtensions.GetLocalized("Master_Dates-Today") + " " + date.ToShortTimeString());
                }
                // Check for yesterday
                else if (date.Date == DateTime.Today.AddDays(-1))
                {
                    return ResourceExtensions.GetLocalized("Master_Dates-Yesterday");
                }
                else
                {
                    return date.ToShortDateString();
                }
            }
            catch
            {
                Debug.WriteLine("DateTimeToFriendlyStringConverter - That wasn't a DateTime object that was inserted you idiot");
                return "Shit's wrecked yo";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}
