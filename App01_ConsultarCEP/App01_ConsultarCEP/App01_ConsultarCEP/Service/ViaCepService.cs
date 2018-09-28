using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Service.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace App01_ConsultarCEP.Service
{
    public class ViaCepService
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static async Task<Endereco> BuscarEnderecoViaCep(string cep)
        {
            WebClient wc = new WebClient();

            string novoEnderecoURL = string.Format(EnderecoURL, cep);
            string content = await wc.DownloadStringTaskAsync(novoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(content);

            if (end.Cep == null) throw new Exception("CEP inválido..");

            return end;
        }
    }
}
