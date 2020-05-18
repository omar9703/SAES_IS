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
    public partial class IngresarProducto : ContentPage
    {
        public IngresarProducto()
        {
            InitializeComponent();
        }

        private void Scan(object sender, EventArgs e)
        {
            //Declarada en Inventario Principal
        }

        private void ScanFotos(object sender, EventArgs e)
        {

        }

        private void IngresaP(object sender, EventArgs e)
        {

        }
    }
}