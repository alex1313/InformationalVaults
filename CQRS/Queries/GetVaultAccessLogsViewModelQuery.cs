namespace CQRS.Queries
{
    using System.Linq;
    using Criteria;
    using DomainModel.ViewModels;

    public class GetVaultAccessLogsQuery : QueryBase<IdCriterion, VaultAccessLogsViewModel[]>
    {
        public override VaultAccessLogsViewModel[] Execute(IdCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                //TODO: mapping
                return uow.VaultAccessLogRepository
                    .Get(x => x.VaultId == criterion.Id)
                    .Select(x => new VaultAccessLogsViewModel
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