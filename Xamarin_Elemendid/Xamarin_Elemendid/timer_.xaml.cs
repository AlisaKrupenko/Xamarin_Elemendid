﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Elemendid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class timer_ : ContentPage
    {
        Button timerButton;
        bool alive = true;
        public timer_()
        {
                timerButton = new Button
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                    BorderWidth = 3,
                    BorderColor = Color.DarkBlue,
                    BackgroundColor = Color.LightBlue
                };
                timerButton.Clicked += TimerButton_Clicked;

                Content = timerButton;

                Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            }
            private bool OnTimerTick()
            {
                timerButton.Text = DateTime.Now.ToString("T");
                return alive;
            }

            private void TimerButton_Clicked(object sender, EventArgs e)
            {
                if (alive == true)
                {
                    alive = false;
                }
                else
                {
                    alive = true;
                    Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
                }
            }

        }
}