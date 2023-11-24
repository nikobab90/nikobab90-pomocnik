namespace Pomocnik.Model;

public class GetAllIspitivanjeResponseVM
{
    //public List<GetIspitivanjeResponseVM> Ispitivanja { get; set; }
    //public int Id { get; set; }

    public string SerijskiBroj { get; set; } = null!;

    public string TvornickiBroj { get; set; } = null!;

    public DateTime DatumOd { get; set; }
    
    public DateTime DatumDo { get; set; }
    
    public decimal Cijena { get; set; }

    public decimal Pdv { get; set; }
    
    public string Tvrtka { get; set; }
    
    public string Naziv { get; set; }
    
    public string AdresaIspitivanja { get; set; }
    
    public string Ime { get; set; } = null!;
    
    public string Prezime { get; set; } = null!;
    
 
    
}
