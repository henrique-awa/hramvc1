using dotnetstarter.Options;
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
        private static LanguageTranslatorService _languageTranslator;
        //{
        //    get { return _languageTranslator ?? new LanguageTranslatorService(); }
        //    set { }
        //}

        private static Service _instance;
        public static Service Instance(LanguageTranslatorOptions options)
        {
            _instance = _instance ?? new Service();

            if (_languageTranslator == null)
                _languageTranslator = new LanguageTranslatorService();
        
            // set the credentials
            _languageTranslator.SetCredential(options.UserName, options.Password);

            return _instance;
        }

        private Service() { }

        public List<SelectListItem> GetLanguages()
        {
            List<SelectListItem> returnItems = new List<SelectListItem>();
            //LanguageTranslatorService _languageTranslator = GetConnectionObject();

            IdentifiableLanguages _IdentifiableLanguages = _languageTranslator.GetIdentifiableLanguages();

            foreach (IdentifiableLanguage result in _IdentifiableLanguages.Languages)
            {
                returnItems.Add(new SelectListItem { Value = result.Language, Text = result.Name });
            }

            return returnItems;
        }

        //public LanguageTranslatorService GetConnectionObject()
        //{
        //    // create a Language Translator Service instance
        //    LanguageTranslatorService _languageTranslator = new LanguageTranslatorService();

        //    // set the credentials
        //    _languageTranslator.SetCredential("2c4ca4bc-b487-4cae-ae90-165ba014a475", "wZNKed7jxK3x");

        //    return _languageTranslator;
        //}

    }
}
