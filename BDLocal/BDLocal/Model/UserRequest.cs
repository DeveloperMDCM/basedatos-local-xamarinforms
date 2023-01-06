using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BDLocal.Model;
using RestSharp;

namespace BDLocal
{
    public class UserRequest
    {
        private HttpClient _restclient;
        public UserRequest(HttpClient restclient)
        {

            if (restclient != null) _restclient = restclient;
            else throw new NullReferenceException("El cliente http no puede hacer null");

        }
        public async Task<List<Comida>> All()
        {


            var response = await _restclient.ExcecuteAsync<List<Comida>>(Method.GET, $"{App.BaseUrl}/Comidas/all/comidas");
            if (response != null) return response.Result;

            return new List<Comida>();

        }

        public async Task<bool> Add(Comida comida)
        {
            var response = await _restclient.ExcecuteAsync<Comida>(Method.POST, $"{App.BaseUrl}/Comidas/add/comidas", new Dictionary<string, object>
            {
                { "NombreComida", comida.NombreComida},
                { "Categoria", comida.Categoria},
                { "Descripcion", comida.Descripcion},
                { "Costo", comida.Costo}
            });

            return response.Result != null;

        }
        public async Task<bool> Update(Comida comida, int id)
        {
            var response = await _restclient.ExcecuteAsync<Comida>(Method.POST, $"{App.BaseUrl}/Comidas/Update/{id}", new Dictionary<string, object>
            {
                { "NombreComida", comida.NombreComida},
                { "Categoria", comida.Categoria},
                { "Descripcion", comida.Descripcion},
                { "Costo", comida.Costo}
            });

            return response.Result != null;

        }

        public async Task<bool> Delete(int id)
        {
            var response = await _restclient.ExcecuteAsync<StatusResponse>(Method.GET, $"{App.BaseUrl}/Comidas/Delete/{id}");
            return response.Result != null && response.Result.code == 401;
        }
    }
}

