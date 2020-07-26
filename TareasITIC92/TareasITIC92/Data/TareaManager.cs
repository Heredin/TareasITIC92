using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TareasITIC92.Data
{
    public class TareaManager
    {
        public const string url = "http://192.168.0.100:3000/tareas/";
        

        public async Task<IEnumerable<Tarea>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Tarea>>(result);
        }

        public async Task<Tarea> Add(string titulo, string detalle)
        {
            Tarea tarea = new Tarea()
            {
                Titulo = titulo,
                Detalle = detalle
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(tarea),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Tarea>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Tarea> Update(string titulo, string detalle,string itemIndex)
        {
            Tarea tarea = new Tarea()
            {
                Titulo = titulo,
                Detalle = detalle
            };
            HttpClient client = new HttpClient();
            var response = await client.PutAsync(url + itemIndex,
                new StringContent(
                    JsonConvert.SerializeObject(tarea),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Tarea>(
                response.Content.ReadAsStringAsync().Result);
          

        }
        public async Task DeleteTareaAsync(string itemIndex)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync(string.Concat(url, itemIndex));
      
        }

        internal Task Add(object text1, object text2)
        {
            throw new NotImplementedException();

        }
        internal Task Update(object text1, object text2,string itemIndex)
        {
            throw new NotImplementedException();

        }

       


    }


}
