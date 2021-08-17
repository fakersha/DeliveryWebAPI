using DeliveryWebAPI.Domain;
using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryWebAPI.Services.Implementations
{
    public class BranchService : IBranchService
    {

        private readonly ApplicationDbContext _context;

        public BranchService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Branch GetBranchById(int id)
        {
            var branch = _context.Branches.FirstOrDefault(branch => branch.Id == id);

            return branch;
           
        }

        public IQueryable<Branch> GetBranches()
        {
           return _context.Branches;
        }
    }
}
