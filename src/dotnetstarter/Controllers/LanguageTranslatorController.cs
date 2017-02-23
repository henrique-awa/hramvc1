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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnetstarter.Controllers
{
    public class LanguageTranslatorController : Controller
    {
        public IActionResult Index()
        {
            Idioma lang = new Idioma { ListaIdiomas = Service.Instance.GetLanguages() };

            return View(lang);
        }
    }
}
