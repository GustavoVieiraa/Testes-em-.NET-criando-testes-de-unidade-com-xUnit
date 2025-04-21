using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2020-01-01", "2020-01-02", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-01-01", "2024-03-03", 80.0, true)]
        [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
        [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino,
            string dataIda, string dataVolta, double preco, bool validacao)
        {
            // Padrão Triplo A - AAA (Arrange, Act e Assert)

            //cenário - arrange
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            //ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //validação - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 3, 3));
            double preco = 80.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeDataInvalidaQuandoDataDeIdaMaiorQueDataDeVolta()
        {
            //arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 6, 6), new DateTime(2024, 3, 3));
            double preco = 80.0;

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-250)]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorOuIgualAZero(double preco)
        {
            //arrange
            Rota rota = new Rota("Origem1", "Destino1");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }
    }
}