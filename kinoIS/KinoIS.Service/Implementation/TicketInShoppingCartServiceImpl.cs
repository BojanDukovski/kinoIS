﻿using KinoIs.Repository.Interface;
using KinoIS.Domain.Relations;
using KinoIS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinoIS.Service.Implementation
{
    public class TicketInShoppingCartServiceImpl : TicketInShoppingCartService
    {
        TicketInShoppingCartRepository ticketInShoppingCartRepository;
        public TicketInShoppingCartServiceImpl(TicketInShoppingCartRepository ticketInShoppingCartRepository)
        {
            this.ticketInShoppingCartRepository = ticketInShoppingCartRepository;
        }
        public List<TicketInShoppingCart> findAll()
        {
            return this.ticketInShoppingCartRepository.findAll();
        }

        public List<TicketInShoppingCart> findAllByShoppingCartId(Guid id)
        {
            return this.ticketInShoppingCartRepository.findAllByShoppingCartId(id);
        }
    }
}
