using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Data
{
    public class ContextRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContextRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Context context)
        {
            _dbContext.Contexts.Add(context);
        }

        public List<Context> FindUserOwnedContexts(string userId)
        {
            return _dbContext.Contexts.Where(c => c.OwnerUserId == userId).ToList();
        }

        public List<Context> GetAll()
        {
            return _dbContext.Contexts.ToList();
        }

        public Context FindById(string id)
        {
            return _dbContext.Contexts.SingleOrDefault(context => context.Id == id);
        }
    }
}