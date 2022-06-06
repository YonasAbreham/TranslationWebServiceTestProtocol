using BusinessLogic.Translations;
using Common.Translation;
using Data.Model.Translation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationWebService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;
        private readonly CheckInput _checkInput;

        public TranslationController(ITranslationService translationService, CheckInput checkInput)
        {
            _translationService = translationService;
            _checkInput = checkInput;
        }

        [HttpGet("{languageCode}/{keyWord}")]
        public async Task<ActionResult> GetTransaltion(string languageCode, string keyWord)
        {
            try
            {
                    var translation = await _translationService.FindTranslationAsync(languageCode, keyWord);
                    if (translation == null)
                        return BadRequest();
                    return Ok(translation.LanguageCode + " => " + translation.Translations);               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostTransaltion([FromBody] Translation translation)
        {

            try
            {
                if (String.IsNullOrEmpty(translation.KeyWord) && String.IsNullOrEmpty(translation.LanguageCode) && String.IsNullOrEmpty(translation.Translations))
                {
                    return BadRequest();
                }

                if (_checkInput.CheckInputValue(translation.LanguageCode, translation.KeyWord))
                {
                    await _translationService.CreateTranslationAsync(translation);

                    return Accepted("Translation created");
                }
                else
                {
                    return BadRequest("Invalid value");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
