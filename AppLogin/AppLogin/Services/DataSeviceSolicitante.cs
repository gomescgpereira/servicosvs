using AppLogin.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Services
{
    public class DataSeviceSolicitante
    {
        HttpClient client = new HttpClient();

        public async Task<List<Solicitante>> GetListaAsync()
        {
            try
            {
                client.BaseAddress = new Uri("http://eccoengmdp.hopto.org:8100/uso/");
                //api / tecnico / ConsultarTecnicos

                var resp = await client.GetAsync("api/solicita/ConsultarSolicitantes");
                if (resp.IsSuccessStatusCode)
                {
                    var respstr = await resp.Content.ReadAsStringAsync();
                    var solicitados = JsonConvert.DeserializeObject<List<Solicitante>>(respstr);
                    return solicitados;

                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task AddTecnicoAsync(Solicitante item)
        {
            try
            {
                var url = new Uri("http://eccoengmdp.hopto.org:8100/uso/api/solicita/CadastrarSolicitante");
                //var uri =  new Uri(string.Format(url,item));
                var data = JsonConvert.SerializeObject(item);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
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

        public async Task UpdateTecnicoAsync(Solicitante item)
        {
            try
            {
                string url = "http://eccoengmdp.hopto.org:8100/uso/api/solicita/AlterarSolicitante{0}";
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

        public async Task DeleteTecnicoAsync(Solicitante item)
        {
            string url = "http://eccoengmdp.hopto.org:8100/uso/api/solicita/CadastrarSolicitante/{0}";
            var uri = new Uri(string.Format(url, item.Id));
            await client.DeleteAsync(uri);
        }

        public async Task<Solicitante> ExisteTecnicoAsync(Solicitante item)
        {
            client.BaseAddress = new Uri("http://eccoengmdp.hopto.org:8100/uso/");
            //api / tecnico / ConsultarTecnicos
            int id = 0;
            var resp = await client.GetAsync("api/solicita/CadastrarSolicitante/{0}");
            if (resp.IsSuccessStatusCode)
            {
                var respstr = await resp.Content.ReadAsStringAsync();
                var solicita = JsonConvert.DeserializeObject<Solicitante>(respstr);

                return solicita;

            }

            return null;
        }

    }
}

