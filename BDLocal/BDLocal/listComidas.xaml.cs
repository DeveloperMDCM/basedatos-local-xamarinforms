using BDLocal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDLocal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listComidas : ContentPage
    {
        ObservableCollection<Comida> _items;
        public listComidas(List<Comida> comidas)
        {
            InitializeComponent();
            
                _items = new ObservableCollection<Comida>();

                lista.ItemsSource = _items;
                //para refrescar, true
                lista.IsPullToRefreshEnabled = true;

                lista.Refreshing += Lista_Refreshing;
                lista.ItemSelected += Lista_ItemSelected;
                lista.ItemTapped += Lista_ItemTapped;
                //Iteramos la lista

                foreach (var usuario in comidas)
                {
                    _items.Add(usuario);
                }

            }

            private void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
            {
                Comida details = e.Item as Comida;
                if (details != null)
                {
                //    Navigation.PushAsync(new AddComida(details));
                }
            }

            private void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                //para eviatar que se coloree
                lista.SelectedItem = null;
            }

            private async void Lista_Refreshing(object sender, EventArgs e)
            {
                await Refrescar();
                lista.EndRefresh();
            }

            private async void BtnAdd_Clicked(object sender, EventArgs e)
            {
              //  await Navigation.PushAsync(new AddComida(), true);
            }

            private async Task Refrescar()
            {
                _items.Clear();
                var listusers = await new UserRequest(App.RestClient).All();
                foreach (var item in listusers)
                {
                    _items.Add(item);
                }
                lista.EndRefresh();
            }

            private async void btnEliminar_Clicked(object sender, EventArgs e)
            {
                bool res = await DisplayAlert("Message", "Seguro que quieres eliminar el usuario?", "Ok", "Cancel");
                if (res)
                {
                    var menu = sender as MenuItem;
                    Comida details = menu.CommandParameter as Comida;

               //     var result = await new UserRequest(App.RestClient).Delete(details.id);
                    await Refrescar();
                }
            }


        }
    }
    
