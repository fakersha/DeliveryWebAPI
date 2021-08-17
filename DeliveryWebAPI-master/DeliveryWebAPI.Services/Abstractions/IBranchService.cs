using DeliveryWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryWebAPI.Services.Abstractions
{
    public interface IBranchService
    {

        Branch GetBranchById(int id);

        IQueryable<Branch> GetBranches();
        
    }
}
