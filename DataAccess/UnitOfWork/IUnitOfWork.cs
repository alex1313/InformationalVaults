namespace DataAccess.UnitOfWork
{
    using System;
    using DomainModel.Entities;
    using Repositories;

    public interface IUnitOfWork : IDisposable
    {
        RepositoryBase<User> UserRepository { get; }
        RepositoryBase<Vault> VaultRepository { get; }

        void Commit();
    }
}