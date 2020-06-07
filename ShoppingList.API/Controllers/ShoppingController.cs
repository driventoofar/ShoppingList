using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.API.Models;
using System;
using System.Threading.Tasks;

namespace ShoppingList.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly ShoppingContext _context = null;

        public ShoppingController(ShoppingContext context)
        {
            _context = context;
            var item = new ListItem
            {
                Id = Guid.NewGuid(),
                Item = "Apple",
                Name = "Andrew"
            };
            _context.Add(item);
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<ListItem>> GetItems()
        {
            var items = await _context.ShoppingList.ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<ListItem>> Post(ListItem listItem)
        {
            _context.ShoppingList.Add(listItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ListItem), new { id = listItem.Id }, listItem);
        }

        [HttpDelete]
        public async Task<ActionResult<ListItem>> Delete(ListItem listItem)
        {
            _context.ShoppingList.Remove(listItem);
            await _context.SaveChangesAsync();

            return listItem;
        }
    }
}
