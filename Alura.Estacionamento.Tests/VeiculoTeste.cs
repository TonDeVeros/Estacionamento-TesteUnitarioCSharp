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
        //isso � o setup para a realiza��o dos testes
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            //toda vez que o construtor for invocado ele escrever� isso.
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();   
        }



        [Fact(DisplayName = "Testa Veiculo Acelerar Com Parametro 10")]
        [Trait("Funcionalidade", "Acelerar")]
        [Description("Testa o m�todo de acelerar")]
        
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange //Inst�ncia dos objetos
            //var veiculo = new Veiculo();

            //Act //Utiliza��o dos m�todos
            veiculo.Acelerar(10);

            //Assert //Verifica��o dos dados
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact]       
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //ao inves de ser inicializado aqui,
            //esta sendo inicializado no come�o da classe(linha 13)
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip ="Teste ainda n�o implementado. Ignore")]
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
            Assert.Contains("Ficha do ve�culo", dados);


        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomePropriet�rio = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                //Aqui o construtor de Veiculo sendo invocado � a execucao da funcao anonima
                () => new Veiculo(nomePropriet�rio)
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
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
            
            //n�o sei por que mas o caractere de ordinal veio diferente no teste abaixo.
            //Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose Invocado.");
            SaidaConsoleTeste.WriteLine("Execu��o do Cleanup: Limpando os objetos.");

            //Output.WriteLine("Execu��o do Cleanup: Limpando os objetos.");
        }
    }
}
