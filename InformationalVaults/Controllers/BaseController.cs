namespace InformationalVaults.Controllers
{
    using System.Web.Mvc;
    using CQRS.Commands.Infrastructure;
    using CQRS.Queries.Infrastructure;

    public class BaseController : Controller
    {
        public IQueryBuilder QueryBuilder { get; set; }

        public ICommandBuilder CommandBuilder { get; set; }
    }
}