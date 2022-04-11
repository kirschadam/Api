using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiEF_react_termekek.Models;
using WebApiEF_react_termekek.Services;

namespace WebApiEF_react_termekek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TermekController : Controller
    {
        private readonly TermekService termekService;
        public TermekController (TermekService termekService)
        {
            this.termekService = termekService;
        }

        [HttpGet]
        [Route("/Termekek")]
        public IEnumerable<Termekek> GetTermekek()
        {
            return termekService.GetTermekek();
        }

        [HttpGet]
        public Termekek GetTermekById(int id)
        {
            return termekService.GetTermekById(id);
        }

        [HttpPost]
        public string AddTermek(Termekek termek)
        {
            return termekService.AddTermek(termek);
        }

        [HttpPut]
        public string UpdateTermek (Termekek termek)
        {
            return termekService.UpdateTermek(termek);
        }

        [HttpDelete]
        public string DeleteTermek (int id)
        {
            return termekService.DeleteTermek(id);
        }

    }
}
