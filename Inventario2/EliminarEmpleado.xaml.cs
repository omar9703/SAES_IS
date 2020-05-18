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
    public partial class EliminarEmpleado : ContentPage
    {
        public EliminarEmpleado()
        {
            InitializeComponent();
        }
        private void SearchBarEmp(object sender, EventArgs e)
        {//Ya la declare en Empleados Pagina Principal


        }

        private void Advertencia(object sender, EventArgs e)
        {
            DisplayAlert("Advertencia", "¡Estas a punto de eliminar un empleado!", "OK");
        }

        private void EliminaEmp(object sender, EventArgs e)
        {

        }
    }
}