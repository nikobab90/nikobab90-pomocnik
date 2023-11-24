namespace Pomocnik.Model;

public class GetKlijentResponseVM
{
    public string Naziv { get; set; } = null!;
    public string Oib { get; set; } = null!;
    public int OvlastenikId { get; set; }
    public string ImeOvlastenika { get; set; } = null!;
    public string PrezimeOvlastenika { get; set; } = null!;
    
}