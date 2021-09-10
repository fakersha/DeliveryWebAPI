﻿using DeliveryWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Services.Abstractions
{
  public  interface IStorageServices
    {

        IQueryable<StorageProduct> GetMainStorageProducts();
        IQueryable<StorageProduct> GetBranchStorageProducts(int branchId);
        Task<bool> AddProduct(StorageProduct product);
        Task<bool> DeleteProduct(int productId);

    }
}
