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
        public Empleado()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var list = await App.client.GetTable<Usuario>().Where(u => (u.rol == "Administrativo" || u.rol == "Profesor")).ToListAsync();
                
                
                postListView.ItemsSource = list;
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
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Agregar Profesor","Agregar Administrativo" ,"Eliminar Empleado");
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
                case "Eliminar Empleado":
                    //Abrir vista/pagina Eliminar Empleado
                    await Navigation.PushAsync(new EliminarEmpleado());
                    break;
                
            }

        }
    }
}