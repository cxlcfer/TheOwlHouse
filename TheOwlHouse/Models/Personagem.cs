namespace TheOwlHouse.Models;

public class Personagem
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public string Especie { get; set; }
    public List<string> Coven { get; set; }

    public string Imagem { get; set; }



public Personagem()
{
    Coven = new List<string>();
}

}
