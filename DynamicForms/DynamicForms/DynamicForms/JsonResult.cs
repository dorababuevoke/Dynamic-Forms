using System.Collections.Generic;

namespace DynamicForms
{
    public class JsonResult
    {
        public string PageTitle { get; set; }
        public List<BaseControl> Controls;
        public JsonResult()
        {
            Controls = new List<BaseControl>();
        }
    }
}
