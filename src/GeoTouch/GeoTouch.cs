﻿using System;

using Xamarin.Forms;

namespace GeoTouch
{
    public class App : Application
    {
        public App()
        {
            MainPage = new HomePage ();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}