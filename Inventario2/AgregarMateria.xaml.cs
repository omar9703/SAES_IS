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
    public partial class AgregarMateria : ContentPage
    {
        public AgregarMateria()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<String> t = new List<string>();
            var list = await App.client.GetTable<Usuario>().Where(u => u.rol == "Profesor").ToListAsync();
           for (int s=0;s<list.Count;s++)
            {
                t.Add(list[s].nombre);
            }
            pickerLugar.ItemsSource = t;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Materia u = new Materia()
                {
                    id = Guid.NewGuid().ToString(),
                    nombre = name.Text,
                    grupo = grupo.Text,
                    horario = hor.Text,
                    planestudios = plan.Text,
                    profesor = pickerLugar.SelectedItem.ToString()
                    
                    
                };
                await App.client.GetTable<Materia>().InsertAsync(u);
                await DisplayAlert("Listo", "Materia Agregada Correctamente", "Aceptar");
                await Navigation.PopAsync();
            }
            catch (MobileServiceInvalidOperationException t)
            {
                await DisplayAlert("ERROR", t.ToString(), "aceptar");
            }
        
    }

        private void pickerLugar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}