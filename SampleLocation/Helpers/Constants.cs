using System;
namespace SampleLocation.Helpers
{
    public static class Constants
    {
        public const string GoogleApiKey = "AIzaSyDcDW5C2SvU9ZXUN01z1PoKxGAAKY-neQ4";
        public const string GoogleBaseUri = "https://maps.googleapis.com/maps/api/place/";
        public const string NearByPlaceUri = GoogleBaseUri + "nearbysearch/json?location={0}&radius=8000&type=restaurant&keyword=cruise&key=" + GoogleApiKey;
        public const string PlaceDetailUri = GoogleBaseUri + "details/json?placeid={0}&key=" + GoogleApiKey;
        public const string PhotoUrl =GoogleBaseUri+ "photo?maxwidth=400&photoreference={0}&key="+ GoogleApiKey;
    }
}
