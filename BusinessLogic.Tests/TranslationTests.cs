using BusinessLogic.Translations;
using Data;
using Data.Model.Translation;
using Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLogic.Tests
{
    public class TranslationTests
    {
        private readonly ITranslationService _translationService;

        public TranslationTests()
        {
            _translationService = new TranslationService(new UnitOfWork(new TranslationWebServiceContext()));
        }

        [Fact]
        public async Task GetTranslation()
        {
            var languageCode = "en";
            var keyWord = "buy-chips";
            var result = await _translationService.FindTranslationAsync(languageCode, keyWord);

            Assert.Equal("Buy chips", result.Translations);
            Assert.Equal("en", result.LanguageCode);
        }
    }
}
