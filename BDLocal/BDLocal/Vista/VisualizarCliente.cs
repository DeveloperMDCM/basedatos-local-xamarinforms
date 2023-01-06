using BDLocal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BDLocal.Vista
{
    class VisualizarCliente
    {
        public ObservableCollection<Comida> Comidas { get; set; }

        public VisualizarCliente()
        {
            Comidas = new ObservableCollection<Comida>();
        }
    }
}
