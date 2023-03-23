using System.Text.Json;
using TheOwlHouse.Models;

namespace TheOwlHouse.Services
{
    public class TohService : ITohService
    {
        private readonly IHttpContextAccessor _session;
        private readonly string personagemFile = @"Data\personagens.json";
        private readonly string covensFile = @"Data\covens.json";
       
        public TohService(IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }

        public List<Personagem> GetPersonagens()
        {
            PopularSessao();
            var personagens = JsonSerializer.Deserialize<List<Personagem>>
            (_session.HttpContext.Session.GetString("Personagens"));
            return personagens;
        }

        public List<Coven> GetCovens()
        {
            PopularSessao();
            var covens = JsonSerializer.Deserialize<List<Coven>>
            (_session.HttpContext.Session.GetString("Covens"));
            return covens;
        }

        public Personagem GetPersonagem(int Numero)
        {
            var personagens = GetPersonagens();
            return personagens.Where(p => p.Numero == Numero).FirstOrDefault();
        }

        public TheOwlHouseDto GetTheOwlHouseDto()
        {
            var persos = new TheOwlHouseDto()
            {
                Personagens = GetPersonagens(),
                Covens = GetCovens()
            };
            return persos;
        }

        public DetailsDto GetDetailedPersonagem(int Numero)
        {
            var personagens = GetPersonagens();
            var perso = new DetailsDto()
            {
                Current = personagens.Where(p => p.Numero == Numero)
            .FirstOrDefault(),
                Prior = personagens.OrderByDescending(p => p.Numero)
            .FirstOrDefault(p => p.Numero < Numero),
                Next = personagens.OrderBy(p => p.Numero)
            .FirstOrDefault(p => p.Numero > Numero),
            };
            return perso;
        }

        public Coven GetCoven(string Nome)
        {
            var covens = GetCovens();
            return covens.Where(t => t.Nome == Nome).FirstOrDefault();
        }

        private void PopularSessao()
        {
            if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Covens")))
            {
                _session.HttpContext.Session
                .SetString("Personagens", LerArquivo(personagemFile));
                _session.HttpContext.Session
                .SetString("Covens", LerArquivo(covensFile));
            }
        }
        
        private string LerArquivo(string fileName)
        {
            using (StreamReader leitor = new StreamReader(fileName))
            {
                string dados = leitor.ReadToEnd();
                return dados;
            }
        }
    }

}
