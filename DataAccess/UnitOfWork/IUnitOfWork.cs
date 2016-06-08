namespace DataAccess.UnitOfWork
{
    using System;
    using DomainModel.Entities;
    using Repositories;

    public interface IUnitOfWork : IDisposable
    {
        RepositoryBase<User> UserRepository { get; }
        RepositoryBase<Role> RoleRepository { get; }
        RepositoryBase<Vault> VaultRepository { get; }
        RepositoryBase<VaultAccessLog> VaultAccessLogRepository { get; }

        void Commit();
    }
}