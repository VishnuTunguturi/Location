using SampleLocation.Interfaces;
using SampleLocation.Services;
using Xamarin.Forms;

namespace SampleLocation
{
    public partial class SampleLocationPage : ContentPage
    {
        ILocalService localService;
        
        public SampleLocationPage()
        {
            InitializeComponent();
            localService = new LocalService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


        }

    }
}
