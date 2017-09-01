using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Geolocator;
using SampleLocation.Interfaces;
using SampleLocation.Models.ResponseModels;
using SampleLocation.Services;

namespace SampleLocation.ViewModels
{
    public class LocationViewViewModel : BaseViewModel
    {
        ILocalService localService;
		private ObservableCollection<PlaceResult> _placeList;
		
		public ObservableCollection<PlaceResult> PlaceList
		{
            get { return _placeList; }
			set
			{
                SetProperty(ref _placeList, value, nameof(PlaceList));
			}
		}


        public LocationViewViewModel()
        {
            localService = new LocalService();
            PlaceList = new ObservableCollection<PlaceResult>();
            //Task.Factory.StartNew(async () => await GetNearByLocation());
        }

        public async Task GetNearByLocation(string latlong="0.0,0.0")
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var result = await localService.GetNearByPlace(latlong);
                if(result.status.ToLower() == "ok")
                {
                    PlaceList =new ObservableCollection<PlaceResult>(result.results.OrderByDescending(a=>a.rating));
                }
            }
            catch(Exception ex)
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
