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
            return await _context.Taxpayers.Where(t => t.Email.Contains(domain)).ToListAsync();
        }

        public async Task<int> GetNumberOfTaxpayers()
        {
            return await _context.Taxpayers.CountAsync();
        }

        public async Task<List<int>> GetLowestAndHighest()
        {
            var lowest = await _context.Taxpayers.OrderBy(t => t.Amount).FirstOrDefaultAsync();
            var highest = await _context.Taxpayers.OrderByDescending(t => t.Amount).FirstOrDefaultAsync();

            var lowestHighest = new List<int>();
            lowestHighest.Add((int)lowest.Amount);
            lowestHighest.Add((int)highest.Amount);

            return lowestHighest;
        }

        public async Task ChangeAmount(string email,int amount)
        {
            var payer = await _context.Taxpayers.FirstOrDefaultAsync(t => t.Email == email);
            if(payer == null)
            {
                throw new ArgumentException("Nincs ilyen email című adózó");
            }
            if (amount < 0)
            {
                payer.DecreaseTaxCredit(amount);
            }
            else
            {
                payer.IncreaseTaxCredit(amount);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddNew(string name, string email, int amount)
        {
            if(await _context.Taxpayers.AnyAsync(t => t.Email == email))
            {
                throw new ArgumentException("Már van ilyen email című adózó");
            }
            var payer = new Taxpayer(name, email);
            if(amount < 0)
            {
                payer.DecreaseTaxCredit(amount);
            }
            else
            {
                payer.IncreaseTaxCredit(amount);
            }
            _context.Taxpayers.Add(payer);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(string email)
        {
            if (!await _context.Taxpayers.AnyAsync(t => t.Email == email))
            {
                throw new ArgumentException("Nincs ilyen email című adózó");
            }
            var payer = await _context.Taxpayers.FirstOrDefaultAsync(t => t.Email == email);

            _context.Remove(payer);

            await _context.SaveChangesAsync();
        }
    }
}
