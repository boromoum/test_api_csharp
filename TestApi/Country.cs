using System.Xml.Linq;

namespace TestApi;

public class Country
{
    public Country(string? name, string? alpha2Code, string? capital, int callingCodes, string? flagUrl, string? timeZone)
    {
        this.Name = name;
        this.Alpha2Code = alpha2Code;
        this.Capital = capital;
        this.CallingCodes = callingCodes;
        this.FlagUrl = flagUrl;
        this.Timezones = timeZone;
    }

    public string? Name { get; set; }

    public string? Alpha2Code { get; set; }

    public string? Capital { get; set; }

    public int CallingCodes { get; set; }

    public string? FlagUrl { get; set; }

    public string? Timezones { get; set; }
}


