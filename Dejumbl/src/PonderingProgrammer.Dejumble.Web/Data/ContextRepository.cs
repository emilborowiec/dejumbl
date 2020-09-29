using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PonderingProgrammer.Dejumble.Web.Model;

namespace PonderingProgrammer.Dejumble.Web.Data
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

        public List<Context> FindUserOwnedContexts(string username)
        {
            return _dbContext.Contexts.Where(c => c.OwnerUserName == username).ToList();
        }

        public List<Context> GetAll()
        {
            return _dbContext.Contexts.ToList();
        }

        public Context Get(string ownerUserName, string contextKey)
        {
            return _dbContext.Contexts.SingleOrDefault(context => context.OwnerUserName == ownerUserName && context.ContextKey == contextKey);
        }

        public Context GetWithRelations(string ownerUserName, string contextKey)
        {
            return _dbContext.Contexts
                             .Include(c => c.Items)
                             .ThenInclude(i => i.OutgoingRelations)
                             .SingleOrDefault(context => context.OwnerUserName == ownerUserName && context.ContextKey == contextKey);
        }

        public Context GetByContentItemId(string contentItemId)
        {
            return _dbContext.Contexts
                             .Include(c => c.Items)
                             .ThenInclude(i => i.OutgoingRelations)
                             .SingleOrDefault(c => c.Items.Any(i => i.Id == contentItemId));
        }
    }
}