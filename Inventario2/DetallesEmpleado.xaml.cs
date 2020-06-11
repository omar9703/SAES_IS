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
    public partial class DetallesEmpleado : ContentPage
    {
        public DetallesEmpleado(Usuario u)
        {
            InitializeComponent();
            nameEmp.Text = u.nombre;
            idEmpAsig.Text = u.boleta;
            correo.Text = u.correo;
            telefono.Text = u.telefono;
            dir.Text = u.direccion;
        }
    }
}