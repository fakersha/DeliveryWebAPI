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
        public IActionResult AddIngredient(string ingredient)
        {
            Ingredient Ingredient = new Ingredient() { Name = ingredient };
            _managerService.AddIngredient(Ingredient);
            return Ok(new { Status = "Success", Message = "ინგრედიენტი წარმატებით დაემატა!" });

        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductModel product)
        {
            Category category = _adminService.GetCategoryById(product.categoryId);
            Product Product = new Product() { Name = product.Name, Price = product.Price, category = category };
            _managerService.AddProduct(Product);
            return Ok(new { Status = "Success", Message = "პროდუქტი წარმატებით დაემატა!" });

        }

        [HttpPost("AddIngredientsInProduct")]
        public IActionResult AddIngredientsInProduct(IngredientsInProductsModel ingredientsInProductsModel)
        {
            Ingredient ingredient = _managerService.FindIngredientById(ingredientsInProductsModel.ingredientId);
            Product product = _managerService.FindProductById(ingredientsInProductsModel.productId);
            ProductWithIngredients productWithIngredients = new ProductWithIngredients() { ingredient = ingredient, product = product};
            _managerService.AddIngredientsInProduct(productWithIngredients);
            return Ok(new { Status = "Success", Message = "ინგრედიენტი პროდუქტს წარმატებით დაემატა!" });

        }


    }
}

