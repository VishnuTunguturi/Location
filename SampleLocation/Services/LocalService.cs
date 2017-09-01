using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleLocation.Helpers;
using SampleLocation.Interfaces;
using SampleLocation.Models.ResponseModels;

namespace SampleLocation.Services
{
    public class LocalService : ILocalService
    {
        private HttpClient _baseClient;

		private HttpClient BaseClient
		{
			get
			{
				var handler = new HttpClientHandler { UseCookies = false };
				_baseClient = new HttpClient(handler);
				return _baseClient;
			}
		}
              
        /// <summary>
        /// Gets the near by place.
        /// </summary>
        /// <returns>The near by place.</returns>
        /// <param name="latlong">Latlong.</param>
        public async Task<NearByResponseModel> GetNearByPlace(string latlong)
        {
			try
			{
                var res = await BaseClient.GetAsync(String.Format(Constants.NearByPlaceUri, latlong));
				res.EnsureSuccessStatusCode();
				var json = await res.Content.ReadAsStringAsync();

				if (string.IsNullOrEmpty(json)) return null;
	            var results = JsonConvert.DeserializeObject<NearByResponseModel>(json);
				return results;

			}	
            catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
        }

        public async Task<string> GetPhotoUrl(string photoreference)
        {
			try
			{
                var res = await BaseClient.GetAsync(String.Format(Constants.PhotoUrl, photoreference));
                if(res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return res.RequestMessage.RequestUri.OriginalString;
                }
				return "";

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return "";
			}
        }

        /// <summary>
        /// Gets the place details.
        /// </summary>
        /// <returns>The place details.</returns>
        /// <param name="placeId">Place identifier.</param>
        public async Task<PlaceDetailResponseModel> GetPlaceDetails(string placeId)
        {
			try
			{
                var res = await BaseClient.GetAsync(String.Format(Constants.PlaceDetailUri, placeId));
				res.EnsureSuccessStatusCode();
				var json = await res.Content.ReadAsStringAsync();

				if (string.IsNullOrEmpty(json)) return null;
                var results = JsonConvert.DeserializeObject<PlaceDetailResponseModel>(json);
				return results;

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
        }
    }
}
