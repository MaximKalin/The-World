using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public class CoordService
    {
        private ILogger<CoordService> _logger;

        public CoordService(ILogger<CoordService> logger)
        {
            _logger = logger;
        }

        public async Task<CoordServiceResult> Lookup(string location)
        {
            var result = new CoordServiceResult()
            {
                Success = false,
                Message = "Failed while looking up coordinates"
            };

            //Look up Coordinates
            var EncodeLocation = WebUtility.UrlEncode(location);
            var ApiKey = Startup.Configuration["AppSettings:GoogleApiKey"];
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={EncodeLocation}&key={ApiKey}";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);


            // Read out the results
            try {
                var results = JObject.Parse(json);
                var status = results["status"];
                var coordsResult = results["results"];

                    if ((string)status == "OK")
                    {
                        var coords = coordsResult[0]["geometry"]["location"];
                        result.Latitude = (double)coords["lat"];
                        result.Longitude = (double)coords["lng"];
                        result.Success = true;
                        result.Message = "Success";
                    }
                    else
                    {
                        result.Message = $"Could not find a '{location}' as a location";
                    }
            }
            catch (Exception ex)
            {
                result.Message = "Internal Error while reading GeoCoordinates Error:"+ex.Message;
            }
            return result;
        }
    }
}
