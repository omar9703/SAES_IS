using Inventario2.modelos;
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
           
           
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            postListView.ItemsSource = await App.client.GetTable<Materia>().ToListAsync();
        }
        private void desde_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void hasta_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
        private async void MenuOp(object sender, EventArgs e)
        { //Despegar menu de  3 opciones Ingresar, Retirar, Detalles
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Ingresar Materia", "Retirar Materia");
            switch (res)
            {
                case "Ingresar Materia":
                    //Abrir vista/pagina Ingresar Producto
                    await Navigation.PushAsync(new AgregarMateria());
                    break;
                case "Retirar Materia":
                    //Abrir vista/pagina Retirar Producto
                    await Navigation.PushAsync(new RetirarProducto());
                    break;

            }
        }
    }
}