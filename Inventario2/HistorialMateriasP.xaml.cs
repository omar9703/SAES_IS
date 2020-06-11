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
    public partial class HistorialMateriasP : ContentPage
    {
        public Usuario o;
        public HistorialMateriasP(Usuario u)
        {
            o = u;
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            postListView.ItemsSource = await App.client.GetTable<Materia>().Where(u => u.profesor == o.nombre).ToListAsync();
        }
    }
}