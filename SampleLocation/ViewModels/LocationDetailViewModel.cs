using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SampleLocation.Helpers;
using SampleLocation.Interfaces;
using SampleLocation.Models.ResponseModels;
using SampleLocation.Services;
using Xamarin.Forms;

namespace SampleLocation.ViewModels
{
	public class LocationDetailViewModel : BaseViewModel
	{
		ILocalService localService;
		private ResultDetail _placeDetail;

        public ResultDetail PlaceDetail
		{
            get { return _placeDetail; }
			set
			{
                SetProperty(ref _placeDetail, value, nameof(PlaceDetail));
			}
		}

        private string _placeId;

        public string PlaceId
		{
			get { return _placeId; }
			set
			{
                SetProperty(ref _placeId, value, nameof(PlaceId));
			}
		}

        private string _photoUrl=string.Empty;

		public string PhotoUrl
		{
            get { return _photoUrl; }
			set
			{
                SetProperty(ref _photoUrl, value, nameof(PhotoUrl));
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleLocation.ViewModels.LocationDetailViewModel"/> class.
        /// </summary>
        /// <param name="placeid">Placeid.</param>
        public LocationDetailViewModel(string placeid)
		{
			localService = new LocalService();
            PlaceDetail = new ResultDetail();
            PlaceId = placeid;
            Task.Factory.StartNew(() => GetLocationDetail());
		}

        /// <summary>
        /// Gets the location detail.
        /// </summary>
        public async void GetLocationDetail()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;
                var result = await localService.GetPlaceDetails(PlaceId);
				if (result.status.ToLower() == "ok")
				{
                    if(result.result.photos.Count>0)
                    {
                        PhotoUrl = await localService.GetPhotoUrl(result.result.photos[0].photo_reference);
                    }
                    
                    PlaceDetail = result.result;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			finally
			{
				IsBusy = false;
			}


		}
	}
}

