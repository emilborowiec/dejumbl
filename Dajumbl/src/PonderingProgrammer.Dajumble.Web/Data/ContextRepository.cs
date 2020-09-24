using System;
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
    }
}