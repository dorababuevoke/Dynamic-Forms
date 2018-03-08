using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Reflection;
using Xamarin.Forms;

namespace DynamicForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DynamicPage("DynamicForms.Data.DynamicForms.json", typeof(App).GetTypeInfo().Assembly));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=9d0bece5-2897-4d3f-a155-f6877612b296", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
