using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AddressBook.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly AddressBook.Models.ContactContext _context;

        public IndexModel(AddressBook.Models.ContactContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; }
        public SelectList States;
        public string SelectedState { get; set; }

        public async Task OnGetAsync(string selectedState, string searchString)
        {
            IQueryable<string> stateQuery = from s in _context.Contact
                                            orderby s.State
                                            select s.State;

            var contacts = from m in _context.Contact
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(selectedState))
            {
                contacts = contacts.Where(s => s.State == selectedState);
            }

            States = new SelectList(await stateQuery.Distinct().ToListAsync());
            Contact = await contacts.ToListAsync();
        }
    }
}
