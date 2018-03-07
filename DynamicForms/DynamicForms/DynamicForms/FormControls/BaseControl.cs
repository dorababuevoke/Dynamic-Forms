namespace DynamicForms
{
    public class BaseControl
    {
        public string Type;
        public string HeadingText { get; set; }
        public bool Visible { get; set; }

        public BaseControl()
        {
            Type = "";
            HeadingText = "";
            Visible = true;
        }
    }
}
