using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SampleLocation.Models.ResponseModels;
using SampleLocation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SampleLocation.Views
{
    public partial class LocationView : ContentPage
    {
        Position _currentGeoPosition;
        LocationViewViewModel lvvm;
        public LocationView()
        {
            InitializeComponent();
            lvvm = new LocationViewViewModel();
            BindingContext = lvvm;


       }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var listview = (ListView)sender;
            var data = listview.SelectedItem as PlaceResult;
            if(data!=null)
            {
                await Navigation.PushAsync(new LocationDetail(data.place_id));   
            }
        }


        protected async override void OnAppearing()
        {
            if(customMap.Pins.Count>0)
            {
                return;
            }

			var userConsent = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
			if (userConsent != PermissionStatus.Granted)
			{
				if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
				{
                    await DisplayAlert("Unable to load map", "Need permission to access location services on the device to load map",  "OK");
				}

				var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
				userConsent = results[Permission.Location];
			}

            if (userConsent == PermissionStatus.Granted)
            {
                var latlong = "0.0,0.0";
				if (CrossGeolocator.IsSupported)
				{
					var locator = CrossGeolocator.Current;
					locator.DesiredAccuracy = 50;
                    var position = await locator.GetPositionAsync();
                    _currentGeoPosition = new Position(position.Latitude, position.Longitude);
					latlong = position.Latitude + "," + position.Longitude;
				}
                await lvvm.GetNearByLocation(latlong);
                foreach(var item in lvvm.PlaceList)
                {
                    Position _geoPosition = new Position(item.geometry.location.lat, item.geometry.location.lng);
					customMap.Pins.Add(new Pin
					{
						Type = PinType.Place,
                        Label = item.name,
						Position = _geoPosition
					});
                }
				customMap.Pins.Add(new Pin
				{
                    Type = PinType.Generic,
					Label = "My Location",
                    Position = _currentGeoPosition
				});
                customMap.MoveToRegion(new MapSpan(_currentGeoPosition, 0.02, 0.02));
            }


            base.OnAppearing();
        }
    }
}
