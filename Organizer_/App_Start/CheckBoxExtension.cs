
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Organizer_.ViewModel
{
    public static class CheckBoxExtension
    {
        public static string CheckBoxList(this HtmlHelper helper, string name, IEnumerable<SelectListItem> items)
        {
            var output = new StringBuilder();
            output.Append(@"<div class=""checkboxList"">");

            foreach (var item in items)
            {
                output.Append(@"<input type=""checkbox"" name=""");
                output.Append(name);
                output.Append("\" value=\"");
                output.Append(item.Value);
                output.Append("\"");

                if (item.Selected)
                    output.Append(@" checked=""chekced""");

                output.Append(" />");
                output.Append(item.Text);
                output.Append("<br />");
            }

            output.Append("</div>");

            return output.ToString();
        }
    }
}