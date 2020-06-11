using Inventario2.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Inventario2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void IniciarSesion(object sender, EventArgs e)
        {
            Boolean y = false;
            int cont = 0;
            var list = await App.client.GetTable<Usuario>().Where(u => u.boleta == bol.Text).ToListAsync();
            for (int x = 0; x < list.Count; x++)
            {
                if (list[x].contrasena == contra.Text)
                {
                    cont = x;
                    y = true;
                    break;
                }

            }
            if (y)
            { 
                if(list[cont].rol=="Administrativo")
                    await Navigation.PushAsync(new Menu(list[cont]));
                if (list[cont].rol == "Profesor")
                    await Navigation.PushAsync(new MenuProfesor(list[cont]));
        }
            else
                await DisplayAlert("error", "Usuario y/o contraseña incorrectos", "Aceptar");
        }
    }
}
