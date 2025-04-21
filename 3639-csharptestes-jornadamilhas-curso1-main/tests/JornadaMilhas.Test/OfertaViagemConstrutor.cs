using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQuandoDadosValidos()
        {
            // Padr�o Triplo A - AAA (Arrange, Act e Assert)

            //cen�rio - arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 3, 3));
            double preco = 80.0;
            var validacao = true;

            //a��o - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //valida��o - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 3, 3));
            double preco = 80.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
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
            Assert.Contains("Erro: Data de ida n�o pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
            
        }

        [Fact]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
        {
            //arrange
            Rota rota = new Rota("Origem", "Destino");
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 3, 3));
            double preco = -300;

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Contains("O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }
    }
}