using JornadaMilhas.Exercicio;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class ExercicioMusicaTest
    {
        [Theory]
        [InlineData("Música Teste")]
        [InlineData("Outra Música")]
        [InlineData("Mais uma Música rs")]
        public void InicializaNomeCorretamenteQuandoCadastraNovaMusica(string nome)
        {
            // Padrão Triplo A - AAA (Arrange, Act e Assert)

            //ação - act
            Musica musica = new Musica(nome);

            //validação - assert
            Assert.Equal(nome, musica.Nome);
        }

        [Theory]
        [InlineData("Música Teste", "Nome: Música Teste")]
        [InlineData("Outra Música", "Nome: Outra Música")]
        [InlineData("Mais uma Música", "Nome: Mais uma Música")]
        public void ExibeDadosDaMusicaCorretamenteQuandoChamadoMetodoExibeFichaTecnica
                (string nome, string saidaEsperada)
        {
            // Arrange
            Musica musica = new Musica(nome);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            musica.ExibirFichaTecnica();
            string saidaAtual = stringWriter.ToString().Trim();

            // Assert
            Assert.Equal(saidaEsperada, saidaAtual);
        }

        [Theory]
        [InlineData(1, "Música Teste", "Id: 1 Nome: Música Teste")]
        [InlineData(2, "Outra Música", "Id: 2 Nome: Outra Música")]
        [InlineData(3, "Mais uma Música", "Id: 3 Nome: Mais uma Música")]
        public void ExibeDadosDaMusicaCorretamenteQuandoChamadoMetodoToString(int id, string nome, string toStringEsperado)
        {
            // Arrange
            Musica musica = new Musica(nome);
            musica.Id = id;

            // Act
            string resultado = musica.ToString();

            // Assert
            Assert.Equal(toStringEsperado, resultado);
        }
    }
}
