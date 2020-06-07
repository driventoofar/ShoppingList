using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.API.Models;

namespace ShoppingList.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly List<ListItem> _items = null;

        public ShoppingController()
        {
            _items = new List<ListItem>()
            {
                new ListItem
                {
                    Id = Guid.NewGuid(),
                    Item = "Apple",
                    Name = "Andrew"
                }
            };
        }

        [HttpGet]
        public IEnumerable<ListItem> GetItems()
        {
            return _items;
        }
    }
}
