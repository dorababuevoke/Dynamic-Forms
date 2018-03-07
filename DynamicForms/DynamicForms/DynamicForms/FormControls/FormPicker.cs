using System.Collections.Generic;

namespace DynamicForms
{
    public class FormPicker : BaseControl
    {
        public int DefaultIndex;
        public List<string> Values;

        public FormPicker()
        {
            DefaultIndex = 0;
            Values = new List<string>();
        }
    }
}
