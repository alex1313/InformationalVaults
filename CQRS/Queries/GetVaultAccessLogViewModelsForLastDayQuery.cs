namespace CQRS.Queries
{
    using System;
    using System.Linq;
    using Criteria;
    using DomainModel.ViewModels;

    public class GetVaultAccessLogViewModelsForLastDayQuery : QueryBase<GetVaultAccessLogViewModelsForLastDayContext, VaultAccessLogViewModel[]>
    {
        public override VaultAccessLogViewModel[] Execute(GetVaultAccessLogViewModelsForLastDayContext criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var yesterday = DateTime.Now.AddDays(-1);
                //TODO: mapping
                return uow.VaultAccessLogRepository
                    .Get(x => x.VaultId == criterion.VaultId && x.DateTimeStamp > yesterday)
                    .Select(x => new VaultAccessLogViewModel
                    {
                        DateTimeStamp = x.DateTimeStamp,
                        UserName = x.User.Email,
                        VaultName = x.Vault.Name,
                        IsAccessDenied = x.IsAccessDenied
                    })
                    .ToArray();
            }
        }
    }
}