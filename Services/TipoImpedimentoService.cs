using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class TipoImpedimentoService
    {
        private readonly SalesWebMvcContext _context;

        public TipoImpedimentoService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<TipoImpedimento>> FindAllAsync()
        {
            return await _context.TipoImpedimento.ToListAsync();
        }
    }
}
