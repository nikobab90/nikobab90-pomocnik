namespace Pomocnik.Model;

public class GetIspitivanjeResponseVM
{
    public int Id { get; set; }

    public string SerijskiBroj { get; set; } = null!;

    public string TvornickiBroj { get; set; } = null!;

    public DateTime DatumOd { get; set; }
    
    public DateTime DatumDo { get; set; }
    
    public decimal Cijena { get; set; }

    public decimal Pdv { get; set; }
    
    public int TvrtkaId { get; set; }
    
    public int VrstaIspitivanjaId { get; set; }
    
    public int LokacijaId { get; set; }
    
    public int ZaposlenikId { get; set; }
}