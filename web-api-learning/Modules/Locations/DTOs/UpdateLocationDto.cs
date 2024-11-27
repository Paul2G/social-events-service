namespace web_api_learning.Modules.Locations.DTOs;

public class UpdateLocationDto
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public int PostalCode { get; set; }
    public string Address { get; set; }
}