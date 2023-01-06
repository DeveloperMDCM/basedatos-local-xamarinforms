using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BDLocal.Model
{
    public class Comida
    {
        
        public int IDComida { get; set; }
        public string NombreComida { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Costo { get; set; }
    }
}
