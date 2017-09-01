﻿using System;
using System.Threading.Tasks;
using SampleLocation.Models.ResponseModels;

namespace SampleLocation.Interfaces
{
    public interface ILocalService
    {
        Task<NearByResponseModel> GetNearByPlace(string latlong);
        Task<PlaceDetailResponseModel> GetPlaceDetails(string placeId);
        Task<string> GetPhotoUrl(string photoreference);
    }
}
