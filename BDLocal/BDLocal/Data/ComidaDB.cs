using BDLocal.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BDLocal.Data
{
    public class ComidaDB
    {
        private readonly SQLiteAsyncConnection database;
        public ComidaDB(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Comida>().Wait();
        }

        public async Task<List<Comida>> GetPersonas()
        {
            return await database.Table<Comida>().ToListAsync();
        }

        public async Task<Comida> BuscarUno(int ID)
        {
            return await database.Table<Comida>().Where(x => x.IDComida == ID).FirstOrDefaultAsync();
        }

        public async Task<int> GuardarPersona(Comida persona)
        {
            if (persona.IDComida != 0)
            {
                return await database.UpdateAsync(persona);
            }
            else
            {
                return await database.InsertAsync(persona);
            }
        }

        public async Task<int> EliminarPersona(Comida persona)
        {
            return await database.DeleteAsync(persona);
        }
    }
}
