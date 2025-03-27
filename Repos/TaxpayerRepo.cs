using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerProject.Models;

namespace TaxpayerProject.Repos
{
    public class TaxpayerRepo
    {
        private readonly TaxpayerContext _context;

        public TaxpayerRepo(TaxpayerContext context)
        {
            _context = context;
        }

        public async Task<List<Taxpayer>> GetAll()
        {
            return await _context.Taxpayers.ToListAsync();
        }

        public async Task<List<Taxpayer>> GetWithminimum(int min)
        {
            return await _context.Taxpayers.Where(t=>t.Amount >= min).ToListAsync();
        }

        public async Task<List<Taxpayer>> GetOrderedByAmount()
        {
            return await _context.Taxpayers.OrderByDescending(t => t.Amount).ToListAsync();
        }

        public async Task<List<Taxpayer>> GetAllWithEmailDomain(string domain)
        {
            return await _context.Taxpayers.Where(t => t.Email.Contains("@gmail.com")).ToListAsync();
        }

        public async Task<int> GetNumberOfTaxpayers()
        {
            return await _context.Taxpayers.CountAsync();
        }
    }
}
