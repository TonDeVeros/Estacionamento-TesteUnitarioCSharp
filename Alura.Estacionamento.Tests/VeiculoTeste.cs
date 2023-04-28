using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.ComponentModel;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    
    public class VeiculoTeste : IDisposable 
    {
        //isso é o setup para a realização dos testes
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            //toda vez que o construtor for invocado ele escreverá isso.
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();   
        }



        [Fact(DisplayName = "Testa Veiculo Acelerar Com Parametro 10")]
        [Trait("Funcionalidade", "Acelerar")]
        [Description("Testa o método de acelerar")]
        
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange //Instância dos objetos
            //var veiculo = new Veiculo();

            //Act //Utilização dos métodos
            veiculo.Acelerar(10);

            //Assert //Verificação dos dados
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact]       
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //ao inves de ser inicializado aqui,
            //esta sendo inicializado no começo da classe(linha 13)
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip ="Teste ainda não implementado. Ignore")]
        public void ValidaNomeProprietario()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange 
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Antonio Santos";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Placa = "SAJ-2305";
            veiculo.Modelo = "Ferrari";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do veículo", dados);


        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietário = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                //Aqui o construtor de Veiculo sendo invocado é a execucao da funcao anonima
                () => new Veiculo(nomeProprietário)
            );

        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF9921";

            //Assert
            var mensagem = Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Placa = placa 
                );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
            
            //não sei por que mas o caractere de ordinal veio diferente no teste abaixo.
            //Assert.Equal("O 4º caractere deve ser um hífen", mensagem.Message);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose Invocado.");
            SaidaConsoleTeste.WriteLine("Execução do Cleanup: Limpando os objetos.");

            //Output.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}
