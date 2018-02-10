using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Model;

namespace AppLogin.Services
{
    public class DataService
    {
        HttpClient client = new HttpClient();

        public async Task<List<Tecnico>> GetListaAsync()
        {
            try
            {
                //client.BaseAddress = new Uri("http://192.168.1.10:3000/tecnico");
                client.BaseAddress = new Uri("http://eccoengmdp.hopto.org:8100/uso/");
                //api / tecnico / ConsultarTecnicos

                var resp = await client.GetAsync("tecnicos");
                if (resp.IsSuccessStatusCode)
                {
                    var respstr = await resp.Content.ReadAsStringAsync();
                    var tecnicos = JsonConvert.DeserializeObject<List<Tecnico>>(respstr);
                    return tecnicos;

                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task AddTecnicoAsync(Tecnico item)
        {
            try
            {
                var url = new Uri("http://eccoengmdp.hopto.org:8100/uso/api/tecnico/CadastrarTecnico");
                //var uri =  new Uri(string.Format(url,item));
                var data = JsonConvert.SerializeObject(item);
                var content = new StringContent(data,Encoding.UTF8, "application/json");
                HttpResponseMessage resp = null;
                resp = await client.PostAsync(url, content);

                if (!resp.IsSuccessStatusCode)
                 {
                    throw new Exception("Erro ao inclui item");
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateTecnicoAsync(Tecnico item)
        {
            try
            {
                string url = "http://eccoengmdp.hopto.org:8100/uso/api/tecnico/AlterarTecnico/{0}";
                var uri = new Uri(string.Format(url, item.Id));
                var data = JsonConvert.SerializeObject(item);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                 {
                    throw new Exception("Erro ao Atualizar item");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteTecnicoAsync(Tecnico item)
        {
            string url = "http://eccoengmdp.hopto.org:8100/uso/api/tecnico/ConsultarTecnicos/{0}";
            var uri = new Uri(string.Format(url, item.Id));
            await client.DeleteAsync(uri);
        }

        public async Task<int> ExisteTecnicoAsync(Tecnico item)
        {
            client.BaseAddress = new Uri("http://eccoengmdp.hopto.org:8100/uso/");
            //client.BaseAddress = new Uri("http://192.168.1.10:3000/tecnico/");
            //api / tecnico / ConsultarTecnicos
            int id = 0;
            var resp = await client.GetAsync("api/tecnico/ConsultarTecnicos");
           // var resp = await client.GetAsync("tecnicos");
            if (resp.IsSuccessStatusCode)
            {
                var respstr = await resp.Content.ReadAsStringAsync();
                var tecnicos = JsonConvert.DeserializeObject<List<Tecnico>>(respstr);

                foreach (Tecnico element in tecnicos)
                {
                    if (element.Token == item.Token)
                    {
                        id = element.Id;
                        return id;
                    }
                }
             
            }

                return id;
        }

    }



}
