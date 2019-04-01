﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01.Servico.Modelo;
using Newtonsoft.Json;

namespace App01.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            String Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null)
                return null;
            else
                return end;
          
        }

    }
}