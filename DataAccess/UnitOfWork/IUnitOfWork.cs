namespace DataAccess.UnitOfWork
{
    using System;
    using DomainModel.Entities;
    using Repositories;

    public interface IUnitOfWork : IDisposable
    {
        RepositoryBase<User> UserRepository { get; }
        RepositoryBase<Vault> VaultRepository { get; }
        RepositoryBase<VaultAccessLog> VaultAccessLogRepository { get; }
        RepositoryBase<Role> RoleRepository { get; }

        void Commit();
    }
}