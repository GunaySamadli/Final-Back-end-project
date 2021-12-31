using Mejuri_Back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Helpers
{
    public class Deleted
    {

        public static void DeleteCompany(Company company, AppDbContext _context)
        {
            if (company.EndTime < DateTime.Now)
            {
                _context.Remove(company);
            }

            _context.SaveChanges();

            return;
        }
    }
}
