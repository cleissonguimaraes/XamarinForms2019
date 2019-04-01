using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App01.Servico.Modelo;
using App01.Servico;

namespace App01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += buscarCEP;
        }

        private void buscarCEP(object sender, EventArgs args)
        {
            //to Do logica do programa

            //To Do validações
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                        RESULTADO.Text = string.Format("Endereço: {2}, {3}, {0} - {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    else
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }

        }

        public bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! o CEP deve conter 8 caracteres.", "OK");
                valido = false;


            }
            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! o CEP deve ser composto apenas por números.", "OK");
                valido = false;
            }


            return valido;

        }
    }
}
