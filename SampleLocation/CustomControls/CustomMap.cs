using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace SampleLocation.CustomControls
{
    public class CustomMap : Map
    {
		public List<CustomPin> CustomPin { get; set; }
		public CustomMap()
		{
			CustomPin = new List<CustomPin>();
		}

	}
}
