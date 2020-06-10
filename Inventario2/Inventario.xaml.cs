using Inventario2.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
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
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var list = await App.client.GetTable<Usuario>().Where(u=>u.rol == "Alumno").ToListAsync();
                
                
                postListView.ItemsSource = list;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                await DisplayAlert("ERROR", e.ToString(), "aceptar");
            }

            
        }

        

        private async void MenuOp(object sender, EventArgs e)
        { //Despegar menu de  3 opciones Ingresar, Retirar, Detalles
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Ingresar Alumno", "Retirar Alumno");
            switch (res)
            {
                case "Ingresar Alumno":
                    //Abrir vista/pagina Ingresar Producto
                    await Navigation.PushAsync(new IngresarProducto());
                    break;
                case "Retirar Alumno":
                    //Abrir vista/pagina Retirar Producto
                    await Navigation.PushAsync(new RetirarProducto());
                    break;
                
            }
        }
    }
}