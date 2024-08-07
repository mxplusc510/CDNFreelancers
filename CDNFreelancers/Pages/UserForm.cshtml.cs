using CDNFreelancers.Data;
using CDNFreelancers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CDNFreelancers.Pages
{
    public class UserFormModel : PageModel
    {
        private readonly AppDbContext _context;

        public UserFormModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public string Title { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Title = "Register New User";
                User = new User();
            }
            else
            {
                Title = "Edit User";
                User = await _context.Users.FindAsync(id);

                if (User == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (User.Id == 0)
            {
                _context.Users.Add(User);
            }
            else
            {
                var existingUser = await _context.Users.FindAsync(User.Id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.Username = User.Username;
                existingUser.Email = User.Email;
                existingUser.PhoneNumber = User.PhoneNumber;
                existingUser.Skillsets = User.Skillsets;
                existingUser.Hobby = User.Hobby;

                _context.Users.Update(existingUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./ListUsers");
        }
    }
}