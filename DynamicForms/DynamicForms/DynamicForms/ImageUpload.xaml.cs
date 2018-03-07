using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DynamicForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageUpload : ContentPage
    {
        public ImageUpload()
        {
            InitializeComponent();

            ButtonUpload.Clicked += ButtonUpload_Clicked;
        }

        private async void ButtonUpload_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
               
            });

            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Directory = "Sample",
            //    Name = "test.jpg"
            //});

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            UploadedImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}