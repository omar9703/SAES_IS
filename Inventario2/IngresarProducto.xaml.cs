using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario2.modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresarProducto : ContentPage
    {
        public IngresarProducto()
        {
            InitializeComponent();
        }

       

        private async void IngresaP(object sender, EventArgs e)
        {
            try
            {
                Usuario u = new Usuario()
                {
                    id = Guid.NewGuid().ToString(),
                    nombre = name.Text,
                    edad = edad.Text,
                    telefono = tel.Text,
                    estudios = "Alumno de Ingenieria en Sistemas",
                    correo = correo.Text,
                    boleta = boleta.Text,
                    contrasena = boleta.Text,
                    direccion = dir.Text,
                    rol = "Alumno"
                };
                await App.client.GetTable<Usuario>().InsertAsync(u);
                await DisplayAlert("Listo", "Alumno agregado Correctamente", "Aceptar");
                await Navigation.PopAsync();
            }
            catch (MobileServiceInvalidOperationException t)
            {
                await DisplayAlert("ERROR", t.ToString(), "aceptar");
            }
            }
    }
}