using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Repositories;
using projekt4.EFCore;
using projekt4.Model;

namespace projekt4.EFCore
{
    public class UnitOfWork : IDisposable
    {
        private EFCoreBrugerRepository _EFCoreBrugerRepo;
        private EFCoreRegisterRepository _EFCoreRegisterRepo;
        private BBMContext _BBMContext;

        public UnitOfWork(BBMContext bBMContext)
        {
            _BBMContext = bBMContext;
        }

        public EFCoreBrugerRepository EFCoreBrugerRepo
        {
            get
            {
                if (_EFCoreBrugerRepo == null)
                {
                    _EFCoreBrugerRepo = new EFCoreBrugerRepository(_BBMContext);
                }
                return _EFCoreBrugerRepo;
            }
        }

        public EFCoreRegisterRepository EFCoreRegisterRepo
        {
            get
            {
                if (_EFCoreRegisterRepo == null)
                {
                    _EFCoreRegisterRepo = new EFCoreRegisterRepository(_BBMContext);
                }
                return _EFCoreRegisterRepo;
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void save()
        {
            _BBMContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _BBMContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
