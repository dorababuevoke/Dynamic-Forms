using System.Reflection;
using Xamarin.Forms;

namespace DynamicForms
{
    public partial class DynamicPage : ContentPage
    {
        StackLayout mainLayout;
        public DynamicPage(string jsonPath, Assembly assembly)
        {
            InitializeComponent();
            PrepareDynamicLayout(jsonPath, assembly);
        }

        public void PrepareDynamicLayout(string path, Assembly assembly)
        {
            mainLayout = new StackLayout { Padding = 20, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand };

            var formControls = JsonParser.GetJsonData(path, assembly);

            if (formControls != null)
            {
                Title = formControls.PageTitle ?? "Dynamic Forms";

                foreach (var item in formControls.Controls)
                {
                    if (item.Visible)
                    {
                        switch (item.Type)
                        {
                            case "Label":
                                mainLayout.Children.Add(DynamicLabel(item));
                                break;

                            case "Entry":

                                mainLayout.Children.Add(DynamicEntry(item));
                                break;

                            case "Picker":

                                mainLayout.Children.Add(DynamicPicker(item));
                                break;

                            case "ImageUpload":

                                mainLayout.Children.Add(DynamicImageUpload(item));
                                break;

                            default: break;
                        }
                    }
                }
            }
            Content = mainLayout;
        }

        private View DynamicImageUpload(BaseControl item)
        {
            PrepareHeadingLabel(item);
            var dd = new ImageUpload();
            return dd.Content;
        }

        private Picker DynamicPicker(BaseControl item)
        {
            PrepareHeadingLabel(item);

            var picker = new Picker
            {
                ItemsSource = ((FormPicker)item).Values,
                SelectedIndex = ((FormPicker)item).DefaultIndex
            };
            return picker;
        }

        private Entry DynamicEntry(BaseControl item)
        {
            PrepareHeadingLabel(item);

            var entry = new Entry
            {
                FontSize = 16,
                Placeholder = ((FormEntry)item).PlaceHolderText
            };
            return entry;
        }

        private Label DynamicLabel(BaseControl item)
        {
            PrepareHeadingLabel(item);

            var label = new Label
            {
                Text = ((FormLabel)item).Text,
                FontSize = 16,
            };
            return label;
        }

        private void PrepareHeadingLabel(BaseControl item)
        {
            mainLayout.Children.Add(new Label
            {
                Text = item.HeadingText,
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
            });
        }
    }
}
