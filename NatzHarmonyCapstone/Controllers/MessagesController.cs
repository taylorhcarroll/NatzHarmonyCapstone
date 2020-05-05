using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NatzHarmonyCapstone.Data;
using NatzHarmonyCapstone.Models;

namespace NatzHarmonyCapstone.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Messages.Include(m => m.Recipient).Include(m => m.Sender);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Messages/Help
        public async Task<IActionResult> Help()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Messages
                .Where(m => m.SenderId == user.Id && m.Recipient.Admin == true || m.RecipientId == user.Id && m.Sender.Admin == true)
                .Include(m => m.Recipient).Include(m => m.Sender);
            return View(await applicationDbContext.ToListAsync());
        }

        // POST: Messages/HelpSend
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HelpSend([Bind("MessagesId,SenderId,RecipientId,Content,TimeStamp,IsRead")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.SenderId);
            return View(messages);
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .Include(m => m.Recipient)
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.MessagesId == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            ViewData["RecipientId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessagesId,SenderId,RecipientId,Content,TimeStamp,IsRead")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.SenderId);
            return View(messages);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages.FindAsync(id);
            if (messages == null)
            {
                return NotFound();
            }
            ViewData["RecipientId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.SenderId);
            return View(messages);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MessagesId,SenderId,RecipientId,Content,TimeStamp,IsRead")] Messages messages)
        {
            if (id != messages.MessagesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessagesExists(messages.MessagesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", messages.SenderId);
            return View(messages);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .Include(m => m.Recipient)
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.MessagesId == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var messages = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(messages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessagesExists(int id)
        {
            return _context.Messages.Any(e => e.MessagesId == id);
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}
