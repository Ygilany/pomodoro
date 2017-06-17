using System.Collections.Generic;

using Xamarin.Forms;

using Pomodoro.Helpers;
using Pomodoro.Views;
using Pomodoro.Services.DataStore;
using System;

namespace Pomodoro
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public static IDictionary<string, string> LoginParameters => null;

        private TimerHelper timer;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            timer = new TimerHelper();
            timer.InitTimer(5 * (int)TimeUnitsInSecondsEnum.Second, LogStuff);
            timer.StartTimer();

            SetMainPage();
        }

        public void LogStuff(object o, EventArgs e) {
            System.Diagnostics.Debug.WriteLine("Log" + this.timer.ElapsedTime);
        }

        public static void SetMainPage()
        {
            if (!UseMockDataStore && !Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                GoToMainPage();
            }
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.RuntimePlatform.Equals(Device.iOS) ? "tab_feed.png" : null
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.RuntimePlatform.Equals(Device.iOS) ? "tab_about.png" : null
                    },
                }
            };
        }
    }
}
