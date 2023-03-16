using TheOwlHouse.Models;
namespace TheOwlHouse.Services
{
    public interface ITohService
    {
        List<Personagem> GetPersonagens();
        List<Coven> GetCovens();
        Personagem GetPersonagem(int Numero);
        TheOwlHouseDto GetTheOwlHouseDto();
        DetailsDto GetDetailedPersonagem(int Numero);
        Coven GetCoven(string Nome);
    }

}
