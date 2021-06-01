﻿using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>(new[] {
new Product() { Id = 1, Name = "Notebook", Price = 100000 },
new Product() { Id = 2, Name = "Car", Price = 2000000 },
new Product() { Id = 3, Name = "Apple", Price = 30 },
});
        private int NextProductId => products.Count() == 0 ? 1 : products.Max(x => x.Id) + 1;

        public ProductsController()
        {
        }

        [HttpGet("GetNextProductId")]
        public int GetNextProductId()
        {
            return NextProductId;
        }

        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = products.Remove(products.SingleOrDefault(p => p.Id == id));

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("{id}")]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.Id = NextProductId;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Product product)
        {
            return Ok(product);
        }


        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storedProduct = products.SingleOrDefault(p => p.Id == product.Id);
            if (storedProduct == null)
            {
                return NotFound();
            }
            storedProduct.Name = product.Name;
            storedProduct.Price = product.Price;
            return Ok(storedProduct);
        }
    }
}
