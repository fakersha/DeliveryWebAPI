using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Models.FrontMappedModels;
using DeliveryWebAPI.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IAdminServices _adminService;

        public ManagerController(IManagerService managerService, IAdminServices adminServices)
        {
            _managerService = managerService;
            _adminService = adminServices;
        }

        [HttpPost("AddIngredient")]
        public async Task<IActionResult> AddIngredientAsync(string ingredient)
        {
            Ingredient Ingredient = new Ingredient() { Name = ingredient };
            var Result = await _managerService.AddIngredient(Ingredient);
            if (Result)
            {
                return Ok(new { Status = "Success", Message = "ინგრედიენტი წარმატებით დაემატა!" });
            }
            return BadRequest(new { Status = "Failed", Message = "ინგრედიენტის დამატება ვერ მოხერხდა" });

        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync(ProductModel product)
        {
            Category category = _adminService.GetCategoryById(product.categoryId);
            Product Product = new Product() { Name = product.Name, Price = product.Price, category = category };
            var Result = await  _managerService.AddProduct(Product);
            if (Result)
            {
                return Ok(new { Status = "Success", Message = "პროდუქტი წარმატებით დაემატა!" });
            }
            return BadRequest(new {Status ="Failed", Message = "როდუქტის დამატება ვერ მოხერხდა!" });

        }

        [HttpPost("AddIngredientsInProduct")]
        public async Task<IActionResult> AddIngredientsInProductAsync(IngredientsInProductsModel ingredientsInProductsModel)
        {
            Ingredient Ingredient = _managerService.FindIngredientById(ingredientsInProductsModel.ingredientId);
            Product Product = _managerService.FindProductById(ingredientsInProductsModel.productId);
            ProductWithIngredients productWithIngredients = new ProductWithIngredients() { ingredient = Ingredient, product = Product};
            var Result = await _managerService.AddIngredientsInProduct(productWithIngredients);
            if (Result)
            {
                return Ok(new { Status = "Success", Message = "ინგრედიენტი პროდუქტს წარმატებით დაემატა!" });
            }
            return BadRequest(new { Status = "Failed", Message = "ინგრედიენტის დამატება ვერ მოხერხდა!" });

        }


    }
}

