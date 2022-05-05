using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamento()
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "germano";
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = "prata";
            veiculo.Modelo = "cerato";
            veiculo.Placa = "aaa-9951";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);
        }
        [Theory]
        [InlineData("Andre","jjj-4455","preto","gol")]
        [InlineData("Jose", "jjj-5500", "branco", "uno")]
        [InlineData("Amanda", "jjj-3091", "vermelho", "voyage")]
        
        public void ValidaFaturamentoComVariosVeiculos(string proprietario,string placa,string cor,string modelo)
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);

        }


    }
}
