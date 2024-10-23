using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class TiposImpedimentosController : Controller
    {
        private readonly TipoImpedimentoService _tipoImpedimentoService;

        public TiposImpedimentosController(TipoImpedimentoService tipoImpedimentoService)
        {
            _tipoImpedimentoService = tipoImpedimentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _tipoImpedimentoService.FindAllAsync();
            return View(list);
        }
    }
}
