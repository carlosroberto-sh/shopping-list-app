using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Models;

namespace ShoppingListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private static List<ShoppingItem> items = new List<ShoppingItem>();
        private static int idCounter = 1;

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingItem>> GetAll() => Ok(items);

        [HttpPost]
        public ActionResult AddItem(ShoppingItem item)
        {
            item.Id = idCounter++;
            items.Add(item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ShoppingItem updatedItem)
        {
            var item = items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            item.Name = updatedItem.Name;
            item.Quantity = updatedItem.Quantity;
            item.Price = updatedItem.Price;
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            items.Remove(item);
            return Ok();
        }
    }
}