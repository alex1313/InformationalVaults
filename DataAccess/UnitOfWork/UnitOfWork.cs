namespace DataAccess.UnitOfWork
{
    using System;
    using DomainModel.Entities;
    using Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly InformationalVaultsContext _context = new InformationalVaultsContext();

        private bool _disposed;

        private RepositoryBase<User> _userRepository;
        private RepositoryBase<Vault> _vaultRepository;
        private RepositoryBase<VaultAccessLog> _vaultAccessLogRepository;

        public RepositoryBase<User> UserRepository => _userRepository ?? (_userRepository = new RepositoryBase<User>(_context));
        public RepositoryBase<Vault> VaultRepository => _vaultRepository ?? (_vaultRepository = new RepositoryBase<Vault>(_context));
        public RepositoryBase<VaultAccessLog> VaultAccessLogRepository => _vaultAccessLogRepository ?? (_vaultAccessLogRepository = new RepositoryBase<VaultAccessLog>(_context));

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}