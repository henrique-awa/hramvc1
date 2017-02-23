using IBM.WatsonDeveloperCloud.LanguageTranslator.v2;
using IBM.WatsonDeveloperCloud.LanguageTranslator.v2.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetstarter.Services
{
    public class Service
    {
        private static Service _instance;
        public static Service Instance
        {
            get
            {
                return _instance ?? new Service();
            }
            private set { }
        }

        private Service() { }

        public LanguageTranslatorService GetConnectionObject()
        {
            // create a Language Translator Service instance
            LanguageTranslatorService _languageTranslator = new LanguageTranslatorService();

            // set the credentials
            _languageTranslator.SetCredential("2c4ca4bc-b487-4cae-ae90-165ba014a475", "wZNKed7jxK3x");

            return _languageTranslator;
        }

        public List<SelectListItem> GetLanguages()
        {
            List<SelectListItem> returnItems = new List<SelectListItem>();
            LanguageTranslatorService _languageTranslator = GetConnectionObject();

            IdentifiableLanguages _IdentifiableLanguages = _languageTranslator.GetIdentifiableLanguages();

            foreach (IdentifiableLanguage result in _IdentifiableLanguages.Languages)
            {
                returnItems.Add(new SelectListItem { Value = result.Language, Text = result.Name });
            }

            return returnItems;
        }
    }
}
