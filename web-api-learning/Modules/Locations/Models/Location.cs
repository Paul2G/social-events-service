namespace web_api_learning.Modules.Locations.Models;

public class Location
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public int PostalCode { get; set; }
    public string Address { get; set; }
}