using BDLocal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDLocal.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleCliente : ContentPage
    {
        public DetalleCliente(Comida comida)
        {
            InitializeComponent();
            NombreC.Text = comida.NombreComida;
            CategoriaC.Text = comida.Categoria;
            DescripcionC.Text = comida.Descripcion;
            CostoC.Text = comida.Costo;
        }
    }
}