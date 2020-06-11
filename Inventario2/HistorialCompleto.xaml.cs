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
        List<Materia> mt = new List<Materia>();
        public HistorialCompleto()
        {
            InitializeComponent();
           
           
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            mt = await App.client.GetTable<Materia>().ToListAsync();
            postListView.ItemsSource = mt;
        }
        

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }
        private async void MenuOp(object sender, EventArgs e)
        { //Despegar menu de  3 opciones Ingresar, Retirar, Detalles
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Ingresar Materia");
            switch (res)
            {
                case "Ingresar Materia":
                    //Abrir vista/pagina Ingresar Producto
                    await Navigation.PushAsync(new AgregarMateria());
                    break;
                
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button.BindingContext as Materia;
            int x = 0;
            await App.client.GetTable<Materia>().DeleteAsync(product);
            mt.Remove(product);
            await DisplayAlert("Borrar", "Materia Borrada Exitosamente","Aceptar");
            postListView.ItemsSource = null;
            postListView.ItemsSource = mt;
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            int y = 0;
            var t = int.TryParse(busqueda.Text, out y);
            if (t)
            {
                var cont = await App.client.GetTable<Materia>().Where(u => u.semestre == busqueda.Text).ToListAsync();
                if (cont.Count == 0)
                    await DisplayAlert("Error", "Materia no encontrada", "Aceptar");
                else
                    postListView.ItemsSource = cont;
            }
            else
            {
                var cont = await App.client.GetTable<Materia>().Where(u => u.nombre == busqueda.Text).ToListAsync();
                if (cont.Count == 0)
                    await DisplayAlert("Error", "Materia no encontrada", "Aceptar");
                else
                    postListView.ItemsSource = cont;
            }
        }
    
    }
}