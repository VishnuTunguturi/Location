using System;
using System.Collections.Generic;
using SampleLocation.ViewModels;
using Xamarin.Forms;

namespace SampleLocation.Views
{
    public partial class LocationDetail : ContentPage
    {
        LocationDetailViewModel ldvm;
        public LocationDetail(string placeid)
        {
            InitializeComponent();
            ldvm = new LocationDetailViewModel(placeid);
            BindingContext = ldvm;
        }
    }
}
