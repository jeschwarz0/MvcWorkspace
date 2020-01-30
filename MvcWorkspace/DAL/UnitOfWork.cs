using System;

namespace ContosoUniversity.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MWContext context = new MWContext();
        //todo: Fill this in with repositories
       /* private GenericRepository<TType> Repository;

        public GenericRepository<TType> Repository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }
        */
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}