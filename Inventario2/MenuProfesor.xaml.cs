﻿using Inventario2.modelos;
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
    public partial class MenuProfesor : ContentPage
    {
        public Usuario p;
        public MenuProfesor(Usuario u)
        {
            p = u;
            InitializeComponent();
        }

        private void Ir_Perfil(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MiPerfil(p));
        }

        private void Ir_Inventario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Inventario());
        }

        private void Ir_Historial(object sender, EventArgs e)
        { //Hacer validacion y si es administrador o de bodega accede al historial completo, si es usuario accede a su historial propio
          //tipo=
          //if (tipo==usuario)

            Navigation.PushAsync(new HistorialCompleto());
        }

        private void Ir_Empleados(object sender, EventArgs e)
        { //Hacer validacion y si es administrador accede, si no no realiza nada
          //tipo=
          //if (tipo==administrador)
            Navigation.PushAsync(new HistorialMateriasP(p));
            //else
            //DisplayAlert("Advertencia", "No Puedes acceder, no eres administrador", "OK");
        }

        private void Ir_Reporte(object sender, EventArgs e)
        { //Hacer validacion y si es usuario accede, si no no realiza nada
          //tipo=
          //if (tipo==usuario)
            Navigation.PushAsync(new LevantarReporte());
        }

        private void Ir_Ajustes(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ajustes());
        }
    }
}