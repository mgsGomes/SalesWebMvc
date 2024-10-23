using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class ColegaService
    {
        private readonly SalesWebMvcContext _context;

        public ColegaService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Colega>> FindAllAsync()
        {
            return await _context.Colega.ToListAsync();
        }
    }
}
