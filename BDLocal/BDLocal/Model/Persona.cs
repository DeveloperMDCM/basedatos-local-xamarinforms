using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BDLocal.Model
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Saldo { get; set; }
        public string Cuentas { get; set; }
    }
}
