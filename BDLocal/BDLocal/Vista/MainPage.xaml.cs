using BDLocal.Model;
using BDLocal.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BDLocal
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        Comida detalles;
        public MainPage(Comida comida = null)
        {
            InitializeComponent();
            if (comida != null)
            {
                btnGuardar.Text = "Editar";
                nombres.Text = comida.NombreComida;
                categoria.Text = comida.Categoria;
                descripcion.Text = comida.Descripcion;
                costo.Text = comida.Costo;
                detalles = comida;
               
            }
        }

        private async void BuscarUno(object sender, EventArgs e)
        {
            detalles = await App.BaseDatos.BuscarUno(Convert.ToInt32(id.Text));
            if (detalles == null)
            {
                await DisplayAlert("Buscar", "Comida No encontrada", "Ok");
            }
            else
            {
                nombres.Text = detalles.NombreComida;
                categoria.Text = detalles.Categoria;
                descripcion.Text = detalles.Descripcion;
                costo.Text = detalles.Costo;
            }
        }

        private async void Insertar(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Guardar")
            {
                btnGuardar.IsEnabled = false;
                var nombre = nombres.Text ?? "";
                var cat = categoria.Text ?? "";
                var des = descripcion.Text ?? "";
                var cost = costo.Text ?? "";
                if (string.IsNullOrEmpty(nombre))
                {
                    await DisplayAlert("Advertencia", "Ingresa un nombre", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(cat))
                {
                    await DisplayAlert("Advertencia", "Ingresa una categoria", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(des))
                {
                    await DisplayAlert("Advertencia", "Ingresa una descripcion", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(cost))
                {
                    await DisplayAlert("Advertencia", "Ingresa un costo", "Aceptar");
                    return;
                }
                UserRequest request = new UserRequest(App.RestClient);
                if (await request.Add(new Comida
                {
                    NombreComida = nombre,
                    Categoria = cat,
                    Descripcion = des,
                    Costo = cost
                }))
                {
                    await DisplayAlert("Mensaje", "Se ha ingresado una comida", "Ok");
                }
                else
                {
                    await DisplayAlert("Mensaje", "No se ha ingresado una comida ", "Ok");
                }
            }
            else
            {
                btnGuardar.IsEnabled = false;
                var nombre = nombres.Text ?? "";
                var cat = categoria.Text ?? "";
                var des = descripcion.Text ?? "";
                var cost = costo.Text ?? "";
                detalles.NombreComida = nombres.Text;
                detalles.Categoria= categoria.Text;
                detalles.Descripcion= descripcion.Text;
                detalles.Costo = costo.Text;

                var result = await new UserRequest(App.RestClient).Update(detalles, detalles.IDComida);
                if (result)
                {
                    await DisplayAlert("Mensaje", "Se ha Actualizado una comida", "Ok");
                }
                else
                {
                    await DisplayAlert("Mensaje", "No se ha podido Actualizar la comida ", "Ok");
                }

            }
            limpiar();
        }

    
        

        private async void Eliminar(object sender, EventArgs e)
        {

            bool res = await DisplayAlert("Message", "Seguro que quieres eliminar la comida?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Comida details = menu.CommandParameter as Comida;

                var result = await new UserRequest(App.RestClient).Delete(details.IDComida);
            }

            limpiar();
        }

        private async void VerTodos(object sender, EventArgs e)
        {
            var listComidas = await new UserRequest(App.RestClient).All();
           await Navigation.PushAsync(new Todos(listComidas));
           
        }

        private void limpiar()
        {
            id.Text = null;
            nombres.Text = "";
            categoria.Text = "";
            descripcion.Text = "";
            costo.Text = "";
        }
    }
}
