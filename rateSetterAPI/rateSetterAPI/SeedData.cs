using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rateSetterAPI
{
    //Class for initializing database with sample data
    public class SeedData
    {
        private LoanDbContext _dbContext;

        public SeedData(LoanDbContext context)
        {
            _dbContext = context;
        }

        public void Seed()
        {
            //prepare and insert the sample data
            var users = new List<Login>
            {
                new Login {Username = "davyJones", Password = "n9G%YE6nnhWG", Role = "lender"},
                 new Login {Username = "jackTaylor", Password = "vhU51&17XZaW", Role = "borrower"},
                new Login {Username = "captainSparrow", Password = "76%Q7xOG3nPK", Role = "lender"},
                new Login {Username = "johnGibbs", Password = "P0$6nq4z2AKN", Role = "borrower"},
            };
            if (!_dbContext.LoginItem.Any())
            {
                _dbContext.LoginItem.AddRange(users);
                _dbContext.SaveChanges();
            }
        }
    }
}
