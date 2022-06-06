using Data.Model.Translation;
using System.Threading.Tasks;

namespace BusinessLogic.Translations
{
    public interface ITranslationService
    {
        Task<Translation> CreateTranslationAsync(Translation translation);
        Task<Translation> FindTranslationAsync(string languageCode, string keyWord);
    }
}