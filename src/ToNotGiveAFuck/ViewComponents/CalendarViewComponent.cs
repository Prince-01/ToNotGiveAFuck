using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToNotGiveAFuck.Models;
using ToNotGiveAFuck.Models.TODOs;

namespace ToNotGiveAFuck.ViewComponents
{
    public class CalendarViewComponent : ViewComponent
    {
        private readonly ToNotGiveAFuckContext _context;

        public CalendarViewComponent(ToNotGiveAFuckContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<TODO> todos)
        {
            return View(todos);
        }
    }
}
