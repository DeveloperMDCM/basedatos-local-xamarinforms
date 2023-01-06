using BDLocal.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BDLocal.Data
{
    public class PersonaDataBase
    {
        private readonly SQLiteAsyncConnection database;
        public PersonaDataBase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Persona>().Wait();
        }

        public async Task<List<Persona>> GetPersonas()
        {
            return await database.Table<Persona>().ToListAsync();
        }

        public async Task<Persona> BuscarUno(int ID)
        {
            return await database.Table<Persona>().Where(x => x.ID == ID).FirstOrDefaultAsync();
        }

        public async Task<int> GuardarPersona(Persona persona)
        {
            if (persona.ID != 0)
            {
                return await database.UpdateAsync(persona);
            }
            else
            {
                return await database.InsertAsync(persona);
            }
        }

        public async Task<int> EliminarPersona(Persona persona)
        {
            return await database.DeleteAsync(persona);
        }
    }
}
