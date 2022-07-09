using KinoIs.Repository.Interface;
using KinoIS.Domain.Models;
using KinoIS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinoIS.Service.Implementation
{
    public class ShoppingCartServiceImpl : ShoppingCartService
    {
        private readonly ShoppingCartRepository shoppingCartRepository;
        public ShoppingCartServiceImpl(ShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;   
        }
        public void deleteById(Guid id)
        {
            this.shoppingCartRepository.deleteById(id);
        }

        public List<ShoppingCart> findAll()
        {
            return this.shoppingCartRepository.findAll();
        }

        public ShoppingCart findById(Guid id)
        {
            return this.shoppingCartRepository.findById(id);
        }

        public ShoppingCart findByOwnerId(string ownerId)
        {
            return this.shoppingCartRepository.findByOwnerId(ownerId);
        }
        public ShoppingCart create(string ownerId)
        {
            return this.shoppingCartRepository.create(ownerId);
        }
    }
}
