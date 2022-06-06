using Data.Model.Translation;
using Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWork
    {
        IRepository<Translation> TranslationRepository { get; }

        Task SaveAsync();
    }


    public class UnitOfWork : IUnitOfWork
    {
        private readonly TranslationWebServiceContext _context;
        private IRepository<Translation> translationRepository;

        public UnitOfWork(TranslationWebServiceContext context)
        {
            _context = context;
        }

        public IRepository<Translation> TranslationRepository 
        {
            get
            {
                if (translationRepository == null)
                {
                    translationRepository = new TranslationRepository(_context);
                }

                return translationRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}