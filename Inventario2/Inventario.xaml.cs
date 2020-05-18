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
    public partial class Inventario : ContentPage
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void SearchBar(object sender, EventArgs e)
        {

        }

        private void Scan(object sender, EventArgs e)
        {

        }

        private async void MenuOp(object sender, EventArgs e)
        { //Despegar menu de  3 opciones Ingresar, Retirar, Detalles
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Ingresar Producto", "Retirar Producto", "Detalles del Producto");
            switch (res)
            {
                case "Ingresar Producto":
                    //Abrir vista/pagina Ingresar Producto
                    Navigation.PushAsync(new IngresarProducto());
                    break;
                case "Retirar Producto":
                    //Abrir vista/pagina Retirar Producto
                    Navigation.PushAsync(new RetirarProducto());
                    break;
                case "Detalles del Producto":
                    //Abrir vista/pagina Detalles del Producto
                    Navigation.PushAsync(new DetallesProducto());
                    break;
            }
        }
    }
}