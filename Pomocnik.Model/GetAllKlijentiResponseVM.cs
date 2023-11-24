namespace Pomocnik.Model;

public class GetAllKlijentiResponseVM
{
    public string Naziv { get; set; } = null!;

    public string Oib { get; set; } = null!;
    
    public string Ovlaštenik { get; set; } = null!;
    
    public string Email { get; set; }
    
    public string BrojMobitela { get; set; }
}