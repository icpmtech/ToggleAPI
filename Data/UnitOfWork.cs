
using Data.Entities;
using Data.Repository;
using System;

namespace Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ToggleContext context = new ToggleContext();
        private Repository<Toggle> toggleRepository;
        private Repository<Service> serviceRepository;

        public Repository<Toggle> ToggleRepository
        {
            get
            {

                if (this.toggleRepository == null)
                {
                    this.toggleRepository = new Repository<Toggle>(context);
                }
                return toggleRepository;
            }
        }
        public Repository<Service> ServiceRepository
        {
            get
            {

                if (this.serviceRepository == null)
                {
                    this.serviceRepository = new Repository<Service>(context);
                }
                return serviceRepository;
            }
        }

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
