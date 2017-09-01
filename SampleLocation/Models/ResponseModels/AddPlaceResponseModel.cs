using System;
namespace SampleLocation.Models.ResponseModels
{
	public class AddPlaceResponseModel
	{
		public string id { get; set; }
		public string place_id { get; set; }
		public string reference { get; set; }
		public string scope { get; set; }
		public string status { get; set; }
	}
}
