using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace sedes.Pages.Room
{
    public class IndexModel : PageModel
    {
        private readonly sedes.Data.RoomContext _context;

        public IndexModel(sedes.Data.RoomContext context)
        {
            _context = context;
        }

        public IList<sedes.Models.Room> Room { get;set; }

        public async Task OnGetAsync()
        {
            Room = await _context.Room.ToListAsync();
        }
    }
}
