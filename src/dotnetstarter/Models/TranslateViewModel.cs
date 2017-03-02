using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetstarter.Models
{
    public class TranslateViewModel
    {
        public String SelectedLanguage { get; set; }
        public List<SelectListItem> ListaIdiomas { get; set; }
    }
}
