using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;

namespace AddressBook.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly AddressBook.Models.ContactContext _context;

        public DetailsModel(AddressBook.Models.ContactContext context)
        {
            _context = context;
        }

        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contact.SingleOrDefaultAsync(m => m.ID == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
