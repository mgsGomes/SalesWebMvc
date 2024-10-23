using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{    
    public class SalesService
    {
        private readonly SalesWebMvcContext _context;

        public SalesService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Seles obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

    }
}
