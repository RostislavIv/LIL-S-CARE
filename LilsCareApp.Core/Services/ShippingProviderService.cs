using LilsCareApp.Core.Contracts;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace LilsCareApp.Core.Services
{
    public class ShippingProviderService : IShippingProviderService
    {
        private readonly ApplicationDbContext _context;

        public ShippingProviderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task GetShippingProvidersAsync()
        {
            // URL of the API endpoint
            string apiUrl = "https://api.speedy.bg/v1/location/office/";

            // Create HttpClient instance
            using (HttpClient client = new HttpClient())
            {

                // POST data
                RequestBody body = new RequestBody
                {
                    userName = "1995918",
                    password = "4148521468",
                    language = "EN",
                    countryId = 100,
                };

                string jsonData = JsonConvert.SerializeObject(body);
                var postData = new StringContent(jsonData, Encoding.UTF8, "application/json");

                try
                {
                    // Make POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, postData);

                    // Check if request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read response content
                        string responseData = await response.Content.ReadAsStringAsync();

                        var offices = JsonConvert.DeserializeObject<Offices>(responseData);

                        List<ShippingOffice> shippingOffices = [];

                        foreach (var office in offices.offices)
                        {
                            ShippingOffice shippingOffice = new ShippingOffice
                            {
                                ShippingProviderId = 2,
                                Price = 7.50m,
                                City = office.address.siteName,
                                OfficeAddress = office.address.localAddressString,
                                OfficeAddressId = office.id,
                            };
                            shippingOffices.Add(shippingOffice);
                        }

                        await _context.ShippingOffices.AddRangeAsync(shippingOffices);
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        // Print error message if request was not successful
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            Console.WriteLine("GetShippingProvidersAsync called");
        }
    }
}

public class OfficeDTO
{
    public int id { get; set; }

    public int TownId { get; set; }

    public string TownName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

}

public class Offices
{
    public Office[] offices { get; set; } = null!;
}

public class RequestBody
{
    public string userName { get; set; } = string.Empty;

    public string password { get; set; } = string.Empty;

    public string language { get; set; } = string.Empty;

    public int countryId { get; set; }
}

public class Office
{
    public int id { get; set; }

    public string name { get; set; } = string.Empty;

    public int siteId { get; set; }

    public Address address { get; set; } = null!;

    public string workingTimeFrom { get; set; } = string.Empty;

    public string workingTimeTo { get; set; } = string.Empty;

    public string workingTimeHalfFrom { get; set; } = string.Empty;

    public string workingTimeHalfTo { get; set; } = string.Empty;

    public string workingTimeToHalfFrom { get; set; } = string.Empty;

    public string workingTimeToHalfTo { get; set; } = string.Empty;

    public string workingTimeDayOffFrom { get; set; } = string.Empty;

    public string workingTimeDayOffTo { get; set; } = string.Empty;

    public string sameDayDepartureCutoff { get; set; } = string.Empty;

    public string sameDayDepartureCutoffHalf { get; set; } = string.Empty;

    public string sameDayDepartureCutoffDayOff { get; set; } = string.Empty;

    public MaxParcelDimensions maxParcelDimensions { get; set; } = null!;

    public double maxParcelWeight { get; set; }

    public string type { get; set; } = string.Empty;

    public int nearbyOfficeId { get; set; }

    public WorkingTimeSchedule[] workingTimeSchedule { get; set; } = [];

    public DateTimeOffset validFrom { get; set; }

    public DateTimeOffset validTo { get; set; }

    public string[] cargoTypesAllowed { get; set; } = [];

}

public class MaxParcelDimensions
{
    public int width { get; set; }

    public int height { get; set; }

    public int depth { get; set; }
}

public class WorkingTimeSchedule
{
    public DateTimeOffset date { get; set; }

    public string workingTimeFrom { get; set; } = string.Empty;

    public string workingTimeTo { get; set; } = string.Empty;

    public string sameDayDepartureCutoff { get; set; } = string.Empty;

    public bool standardSchedule { get; set; }
}

public class Address
{
    public int siteId { get; set; }

    public string siteName { get; set; } = string.Empty;

    public string localAddressString { get; set; } = string.Empty;
}