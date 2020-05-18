using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorialCompleto : ContentPage
    {
        public HistorialCompleto()
        {
            InitializeComponent();
            desde.Date = DateTime.Now;
            desde.MinimumDate = new DateTime(2000, 1, 1);
            desde.MaximumDate = desde.Date;
            desde.DateSelected += desde_DateSelected;

            hasta.Date = DateTime.Now;
            hasta.MinimumDate = new DateTime(2000, 1, 1);
            hasta.MaximumDate = hasta.Date;
            hasta.DateSelected += hasta_DateSelected;
        }

        private void desde_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void hasta_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}