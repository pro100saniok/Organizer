
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Organizer_.ViewModel
{
    public class TagViewModel
    {
        public IEnumerable<int> SelectedTags { get; set; }
        public IEnumerable<SelectListItem> Tags { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
       
    }
}