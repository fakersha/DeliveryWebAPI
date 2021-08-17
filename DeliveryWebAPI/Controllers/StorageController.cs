using AutoMapper;
using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Models.FrontMappedModels;
using DeliveryWebAPI.Services.Abstractions;
using DeliveryWebAPI.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageServices _storageServices;
        private readonly IMapper _mapper;
        private readonly IBranchService _branchService;
        private readonly UserManager<User> _userManager;
        public StorageController(
               UserManager<User> userManager,
               IStorageServices storageServices,
               IMapper mapper,
               IBranchService branchService)
        {
            _userManager = userManager;
            _storageServices = storageServices;
            _mapper = mapper;
            _branchService = branchService;
        }

        //[Authorize(Policy = "ManagerAccess")]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(StorageProductModel model)
        {
            if (ModelState.IsValid)
            {

                var branch = _branchService.GetBranchById(model.BranchId);

                var mappedStorageProduct = _mapper.Map<StorageProduct>(model);
                mappedStorageProduct.Branch = branch;
                await _storageServices.AddProduct(mappedStorageProduct);
                return Ok(new { status = "Successful", description = "Product Added" });
            }

            return BadRequest();


        }
        [HttpGet("GetMainStorage")]
        public IActionResult GetMainStorageProducts()
        {
            var StorageProducts = _storageServices.GetMainStorageProducts();
            return Ok(StorageProducts);
        }


        [HttpGet("GetBranchProduct")]
        public IActionResult GetBranchStorageProducts(int branchId)
        {
            var branchStorageProducts = _storageServices.GetBranchStorageProducts(branchId);
            return Ok(branchStorageProducts);
        }
    }
}
