using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingService;

namespace University.DataLayer.Repositories
{
    public abstract class BaseDataRepository : IDisposable
    {
        private const string CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE = "Tried to use repository with null context";
        private Entities mContext;

        public abstract bool IsEntityTrackingOn { get; set; }

        public virtual Entities Context
        {
            get { return mContext; }
            set
            {
                if (value == null)
                {
                    LogHelper.LogException<BaseDataRepository>(CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE);
                    throw new NullReferenceException(CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE);
                }

                value.Configuration.LazyLoadingEnabled = false;

                mContext = value;
            }
        }

        #region Disposing logic

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}
