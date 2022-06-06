using Data.Model.Translation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
   public class TranslationRepository : GenericRepository<Translation>
   {
        public TranslationRepository(TranslationWebServiceContext context)
            :base(context)
        {

        }

        public override async Task<Translation> AddAsync(Translation entity)
        {
            return await base.AddAsync(entity);
        }


    }
}
