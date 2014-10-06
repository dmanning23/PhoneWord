using System;
using Xamarin.Forms;

namespace PhoneWord
{
    class PhoneWordPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;

        public PhoneWordPage()
        {
            this.Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20);

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = "Enter a phoneword:"
            });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1 800 MIXALOT"
            });

            panel.Children.Add(translateButton = new Button
            {
                Text = "Translate"
            });

            panel.Children.Add(callButton = new Button
            {
                Text = "Call",
                IsEnabled = false
            });

            translateButton.Clicked += OnTranslate;

            this.Content = panel;
        }

        public void OnTranslate(object sender, EventArgs e)
        {
            //Get the text of the translate control
            string translated = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);

            //check if anything was entered
            if (!String.IsNullOrEmpty(translated))
            {
                callButton.Text = "Call " + translated;
                callButton.IsEnabled = true;
            }
            else
            {
                callButton.Text = "Call";
                callButton.IsEnabled = false;
            }

        }
    }
}
