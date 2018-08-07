using App01_ConsultarCEP.Service;
using App01_ConsultarCEP.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCep;
        }

        private async void BuscarCep(object sender, EventArgs args)
        {
            try
            {
                string cep = CEP.Text.Trim();

                ValidaCep(cep);

                Endereco end = await ViaCepService.BuscarEnderecoViaCep(cep);
                RESULTADO.Text = $"Cidade: {end.Localidade}   |   Estado: {end.Uf}   |   Logradouro: {end.Logradouro}   |   Bairro: {end.Bairro}";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Atenção", ex.Message, "OK");
            }
        }

        private void ValidaCep(string cep)
        {
            int novoCEP = 0;
            if (string.IsNullOrEmpty(cep)) throw new Exception("Informe um CEP.");
            if (cep.Length != 8) throw new Exception("O CEP deve conter 8 digitos.");
            if (!int.TryParse(cep, out novoCEP)) throw new Exception("O CEP deve conter apenas números.");
        }
    }
}
