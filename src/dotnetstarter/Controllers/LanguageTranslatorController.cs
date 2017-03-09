using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using IBM.WatsonDeveloperCloud.LanguageTranslator.v2;
using Microsoft.AspNetCore.Mvc.Rendering;
using IBM.WatsonDeveloperCloud.LanguageTranslator.v2.Model;
using dotnetstarter.Models;
using dotnetstarter.Services;
using Microsoft.Extensions.Options;
using dotnetstarter.Options;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnetstarter.Controllers
{
    public class LanguageTranslatorController : Controller
    {
        private LanguageTranslatorOptions Options { get; set; }

        public LanguageTranslatorController(IOptions<LanguageTranslatorOptions> options) 
        {
            Options = options.Value;
        }

        public IActionResult Index()
        {
            Service _service = Service.Instance(Options);

            TranslateViewModel lang = new TranslateViewModel { LanguageList = _service.GetLanguages() };

            return View(lang);
        }
    }
}
