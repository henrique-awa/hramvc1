using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetstarter.Models
{
    public class TranslateViewModel
    {
        public List<SelectListItem> LanguageList { get; set; }
        public String SelectedInputLanguage { get; set; }
        public String SelectedOutputLanguage { get; set; }

        public String InputText { get; set; }
        public String OutputText { get; set; }
    }
}
