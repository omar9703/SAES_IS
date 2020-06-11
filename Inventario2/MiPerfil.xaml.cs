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
    public partial class MiPerfil : ContentPage
    {
        public MiPerfil(Usuario u)
        {
            InitializeComponent();
            name.Text = u.nombre;
            tel.Text = u.telefono;
            dir.Text = u.direccion;
            idPersonal.Text = u.boleta;
            correo.Text = u.correo;
        }
    }
}