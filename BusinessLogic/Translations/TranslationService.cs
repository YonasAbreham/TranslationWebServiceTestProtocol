using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data.Model.Translation;
using Common.Translation;
using System.Threading.Tasks;

namespace BusinessLogic.Translations
{
    public class TranslationService : ITranslationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TranslationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Translation> CreateTranslationAsync(Translation translation)
        {
            var _translation = (await _unitOfWork.TranslationRepository
                .FindAsync(t => t.KeyWord == translation.KeyWord)).SingleOrDefault();

            if (_translation == null)
            {
                _translation = new Translation
                {
                    KeyWord = translation.KeyWord,
                    LanguageCode = translation.LanguageCode,
                    Translations = translation.Translations
                };
            }

           await _unitOfWork.TranslationRepository.AddAsync(_translation);
           await _unitOfWork.SaveAsync();

            return _translation;
        }

        public async Task<Translation> FindTranslationAsync(string languageCode, string keyWord)
        {
            var translation = (await _unitOfWork.TranslationRepository.FindAsync(t => t.LanguageCode == languageCode && t.KeyWord == keyWord)).SingleOrDefault();

            return translation;
        }

        
    }
}
