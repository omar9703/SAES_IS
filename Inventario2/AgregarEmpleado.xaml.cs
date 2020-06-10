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
    public partial class AgregarEmpleado : ContentPage
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
        }
        private void GenerateID(object sender, EventArgs e)
        {//Generar ID usando Data Binding y asignarlo a la variable idEmp

            //var idEmpleado = 04236; 
            //idEmp.Text= idEmpleado.ToString();
        }

        private async void AgregaEmp(object sender, EventArgs e)
        {
            try
            {
                Usuario u = new Usuario()
                {
                    id = Guid.NewGuid().ToString(),
                    nombre = name.Text,
                    edad = edad.Text,
                    telefono = tel.Text,
                    estudios = grado.Text,
                    correo = correo.Text,
                    boleta = boleta.Text,
                    contrasena = boleta.Text,
                    direccion = dir.Text,
                    rol = "Administrativo"
                };
                await App.client.GetTable<Usuario>().InsertAsync(u);
                await DisplayAlert("Listo", "Personal Agregado Correctamente", "Aceptar");
                await Navigation.PopAsync();
            }
            catch (MobileServiceInvalidOperationException t)
            {
                await DisplayAlert("ERROR", t.ToString(), "aceptar");
            }
        }
    

    }
}