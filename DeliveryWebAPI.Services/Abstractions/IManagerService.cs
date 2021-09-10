using AutoMapper;
using DeliveryWebAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Services.Abstractions
{
    public interface IManagerService
    {
        Task<bool> AddIngredient(Ingredient ingredient);

        Task<bool> AddProduct(Product product);

        Task<bool> AddIngredientsInProduct(ProductWithIngredients productWithIngredients);

        Ingredient FindIngredientById(int Id);

        Product FindProductById(int Id);
    }
}
