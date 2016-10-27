using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToNotGiveAFuck.Models;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.ViewComponents
{
    public class QuickAddTodoViewComponent : ViewComponent
    {
        private readonly ToNotGiveAFuckContext _context;

        public QuickAddTodoViewComponent(ToNotGiveAFuckContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["CategoryId"] = _context.Category.Select(c => new SelectListItem { Text = c.Name, Value = c.CategoryId.ToString() });
            ViewData[nameof(Statuses)] = Enum.GetNames(typeof(Statuses)).Select(n => new SelectListItem { Text = n, Value = n });
            ViewData[nameof(Types)] = Enum.GetNames(typeof(Types)).Select(n => new SelectListItem { Text = n, Value = n });
            return View();
        }
    }
}
