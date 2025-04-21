using JornadaMilhas.Exercicio;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class ExercicioMusicaTest
    {
        [Fact]
        public void TesteNomeInicializadoCorretamente()
        {
            // Padrão Triplo A - AAA (Arrange, Act e Assert)

            //cenário - arrange
            string nome = "Tell me Why?";

            //ação - act
            Musica musica = new Musica(nome);

            //validação - assert
            Assert.Equal(nome, musica.Nome);
        }

        [Fact]
        public void TesteIdentificadorInicializadoCorretamente()
        {
            // Padrão Triplo A - AAA (Arrange, Act e Assert)

            //cenário - arrange
            int id = 1;
            string nome = "Tell me Why?";

            //ação - act
            Musica musica = new Musica(nome) { Id = id };

            //validação - assert
            Assert.Equal(id, musica.Id);
        }

        [Fact]
        public void TesteToString()
        {
            // Padrão Triplo A - AAA (Arrange, Act e Assert)

            //cenário - arrange
            int id = 1;
            string nome = "Tell me Why?";
            Musica musica = new Musica(nome);
            musica.Id = id;
            string toStringEsperado = @$"Id: {id} Nome: {nome}";

            //ação - act
            string resultado = musica.ToString();


            //validação - assert
            Assert.Equal(toStringEsperado, musica.ToString());
        }
    }
}
