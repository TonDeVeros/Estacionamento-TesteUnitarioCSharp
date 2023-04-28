using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class PatioTestes : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;
        public Operador operador;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            //toda vez que o construtor for invocado ele escreverá isso.
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
            estacionamento = new Patio();

            operador = new Operador();
            operador.Nome = "Antonio Santos";
            estacionamento.OperadorPatio = operador;
        }


        [Fact] 
        public void ValidaFaturamento()
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Antonio Santos";
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel; //pegando o Enum do tipo de veículo
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Ferrari";
            veiculo.Placa = "SAS-2305";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Antonio Santos", "SAS-2305", "Vermelho", "Ferrari")]
        [InlineData("Douglas Reis", "BRU-0501", "Preto", "Lamborghini")]
        [InlineData("Samara Jaques", "VIV-1321", "Branco", "Porsche")]
        public void ValidaFaturamentoComVariosVeiculos(
              string proprietario
            , string placa
            , string cor
            , string modelo)
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel; //pegando o Enum do tipo de veículo
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Antonio Santos", "SAS-2305", "Vermelho", "Ferrari")]
        [InlineData("Douglas Reis", "BRU-0501", "Preto", "Lamborghini")]
        [InlineData("Samara Jaques", "VIV-1321", "Branco", "Porsche")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(
              string proprietario
            , string placa
            , string cor
            , string modelo)
        {
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel; //pegando o Enum do tipo de veículo
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert.Equal(placa, consultado.Placa);
            Assert.Contains("### Ticket Estacionameno Alura ###", consultado.Ticket);
        }


        [Fact]
        public void ValidaAlterarDadosVeiculo()
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Antonio Santos";
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Ferrari";
            veiculo.Placa = "SAS-2305";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Antonio Santos";
            veiculoAlterado.Placa = "SAS-2305";
            veiculoAlterado.Cor = "Branco";
            veiculoAlterado.Modelo = "Ferrari";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);
            // vai mandar os dados de alteracao e retornar o resultado dentro da variavel alterado


            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);


        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}
