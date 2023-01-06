using BDLocal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDLocal.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Todos : ContentPage
    {
        ObservableCollection<Comida> _items;
       
        public Todos(List<Comida> comida)
        {

            InitializeComponent();
            _items = new ObservableCollection<Comida>();
            Lista.ItemsSource = _items;
            //para refrescar, true
            Lista.IsPullToRefreshEnabled = true;

            Lista.ItemTapped += Lista_ItemTapped;
            //Iteramos la lista

            foreach (var usuario in comida)
            {
                _items.Add(usuario);
            }
        }

        private async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalle = e.Item as Comida;
            await Navigation.PushAsync(new DetalleCliente(detalle));
        }
    }
}