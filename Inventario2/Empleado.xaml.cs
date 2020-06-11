using Inventario2.modelos;
using Microsoft.WindowsAzure.MobileServices;
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
    public partial class Empleado : ContentPage
    {
        List<Usuario> mt = new List<Usuario>();
        public Empleado()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                mt = await App.client.GetTable<Usuario>().Where(u => (u.rol == "Administrativo" || u.rol == "Profesor")).ToListAsync();
                
                
                postListView.ItemsSource = mt;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                await DisplayAlert("ERROR", e.ToString(), "aceptar");
            }

        }
            private void SearchBarEmp(object sender, EventArgs e)
        {
            DisplayAlert("Buscando", "Buscando Resultados", "OK");
        }

        private async void MenuOpEmp(object sender, EventArgs e)
        { //Despegar menu de  3 opciones Agregar, Eliminar, Detalles
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Agregar Profesor","Agregar Administrativo" );
            switch (res)
            {
                case "Agregar Administrativo":
                    //Abrir vista/pagina Agregar Empleado
                    await Navigation.PushAsync(new AgregarEmpleado());
                    break;
                case "Agregar Profesor":
                    //Abrir vista/pagina Agregar Empleado
                    await Navigation.PushAsync(new AgregarProfesor());
                    break;
                
                
            }

        }

        private async void botones_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button.BindingContext as Usuario;
            int x = 0;
            await App.client.GetTable<Usuario>().DeleteAsync(product);
            mt.Remove(product);
            await DisplayAlert("Borrar", "Usuario Borrado Exitosamente", "Aceptar");
            postListView.ItemsSource = null;
            postListView.ItemsSource = mt;
        }

        private async void busqueda_SearchButtonPressed(object sender, EventArgs e)
        {
            int y = 0;
            var t = int.TryParse(busqueda.Text, out y);
            if (t)
            {
                var cont = await App.client.GetTable<Usuario>().Where(u => u.boleta == busqueda.Text).ToListAsync();
                if (cont.Count == 0)
                    await DisplayAlert("Error", "Usuario no encontrado", "Acpetar");
                else
                    postListView.ItemsSource = cont;
            }
            else
            {
                var cont = await App.client.GetTable<Usuario>().Where(u => u.nombre == busqueda.Text).ToListAsync();
                if (cont.Count == 0)
                    await DisplayAlert("Error", "Usuario no encontrado", "Acpetar");
                else
                    postListView.ItemsSource = cont;
            }
        }

        private void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            postListView.SelectedItem = null;
            var selectedPost = postListView.SelectedItem as Usuario;
            if (selectedPost != null)
                Navigation.PushAsync(new DetallesEmpleado(selectedPost));
        }
    }
}