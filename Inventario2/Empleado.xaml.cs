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
        private void SearchBarEmp(object sender, EventArgs e)
        {
            DisplayAlert("Buscando", "Buscando Resultados", "OK");
        }

        private async void MenuOpEmp(object sender, EventArgs e)
        { //Despegar menu de  3 opciones Agregar, Eliminar, Detalles
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Agregar Empleado", "Eliminar Empleado", "Detalles del Empleado");
            switch (res)
            {
                case "Agregar Empleado":
                    //Abrir vista/pagina Agregar Empleado
                    Navigation.PushAsync(new AgregarEmpleado());
                    break;
                case "Eliminar Empleado":
                    //Abrir vista/pagina Eliminar Empleado
                    Navigation.PushAsync(new EliminarEmpleado());
                    break;
                case "Detalles del Empleado":
                    //Abrir vista/pagina Detalles del Empleado
                    Navigation.PushAsync(new DetallesEmpleado());
                    break;
            }

        }
    }
}