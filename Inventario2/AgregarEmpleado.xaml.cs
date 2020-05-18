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

        private void AgregaEmp(object sender, EventArgs e)
        {

        }

    }
}