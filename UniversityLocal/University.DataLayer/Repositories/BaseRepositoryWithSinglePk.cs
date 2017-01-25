using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingService;
using University.Common;
using University.Common.Interfaces;

namespace University.DataLayer.Repositories
{
    public class BaseRepositoryWithSinglePk<T>: BaseRepository<T> where T: class, IDatabaseObjectEntity, IDatabaseObjectEntityWithoutId, new()
    {
        public async Task<T> GetAsync(Guid id, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(entity => entity.Id == id, navigationProperties).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id).ConfigureAwait(false);

            await RemoveAsync(entity).ConfigureAwait(false);
        }

        #region Overrides

        public override Task<T> CreateAsync(T entity, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            return base.CreateAsync(entity, refreshFromDb, navigationProperties);
        }

        public override Task<IList<T>> CreateAsync(IList<T> entities, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            Parallel.ForEach(entities.Where(entity => entity.Id == Guid.Empty), entity => { entity.Id = Guid.NewGuid(); });

            return base.CreateAsync(entities, refreshFromDb, navigationProperties);
        }

        protected override async Task<T> FetchFromDbAsync(T entity, IList<string> navigationProperties = null)
        {
            return await GetAsync(entity.Id, navigationProperties).ConfigureAwait(false);
        }

        protected override bool ValidateEntity(T entity)
        {
            if (entity != null && entity.Id != Guid.Empty)
            {
                return true;
            }

            LogHelper.LogException<BaseDataRepository>("Invalid entity: null or empty primary keys");
            return false;
        }

        #endregion
    }
}

