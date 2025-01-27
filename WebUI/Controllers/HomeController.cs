using System.Diagnostics;
using BusinessLogic.Handler.Command.AddOneQuentity;
using BusinessLogic.Handler.Query.GetTreeAsListString;
using Domain.Entities.StringListTree;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            List<IdAndName> list = _mediator.Send(new GetTreeAsListStringQuery()).Result;
            return View(list);
        }

        public IActionResult AddOneQuentity(AddOneQuentityCommand IdNode)
        {
            _mediator.Send(IdNode);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
