using System;

using Xamarin.Forms;

namespace SampleLocation
{
    public class CustomControls : ContentPage
    {
        public CustomControls()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

