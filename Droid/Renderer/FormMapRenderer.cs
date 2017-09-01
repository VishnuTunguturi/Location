using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using SampleLocation.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(Map), typeof(FormMapRenderer))]
namespace SampleLocation.Droid.Renderer
{
	public class FormMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
	{
        GoogleMap map;
        public Android.Views.View GetInfoContents(Marker marker)
        {
            throw new NotImplementedException();
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            throw new NotImplementedException();
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				var formsMap = (Map)e.NewElement;
				//customPins = formsMap.CustomPins;
				((MapView)Control).GetMapAsync(this);
			}
		}
    }
}
