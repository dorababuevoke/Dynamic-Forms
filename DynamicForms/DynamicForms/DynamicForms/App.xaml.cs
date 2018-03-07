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
