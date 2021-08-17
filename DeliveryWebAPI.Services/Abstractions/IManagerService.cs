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
        void AddIngredient(Ingredient ingredient);

        void AddProduct(Product product);

        void AddIngredientsInProduct(ProductWithIngredients productWithIngredients);

        Ingredient FindIngredientById(int Id);

        Product FindProductById(int Id);
    }
}
