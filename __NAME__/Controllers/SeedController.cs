using System.Web.Mvc;
using Highway.Data.Interfaces;
using __NAME__.Infrastructure.Commands;
using __NAME__.Infrastructure.Database;

namespace __NAME__.Controllers
{
    [LocalOnly]
    public class SeedController : Controller
    {
        private readonly IRepository _repository;

        public SeedController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult PurgeDb()
        {
            _repository.Execute(new PurgeDatabase());

            return new EmptyResult();
        }


        [HttpPost]
        public ActionResult All()
        {
            _repository.Execute(new SeedDatabase());

            return new EmptyResult();
        }

        /// <summary>
        /// Create sample entries for your database in this method.
        /// </summary>
        [HttpPost]
        public ActionResult SampleEntries()
        {
            _repository.Execute(new SeedDatabase());

            return new EmptyResult();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = Content(filterContext.Exception.Message);
            filterContext.ExceptionHandled = true;
        }
    }

    public class LocalOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!RunningLocally(filterContext)) filterContext.Result = new HttpNotFoundResult();
        }

        public bool RunningLocally(ActionExecutingContext filterContext)
        {
            return filterContext.RequestContext.HttpContext.Request.IsLocal;
        }
    }
}