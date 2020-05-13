using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using NatzHarmonyCapstone.Data;
using NatzHarmonyCapstone.Models;
using NatzHarmonyCapstone.Models.ViewModels;

namespace NatzHarmonyCapstone.Controllers
{
    [Authorize]
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


            if (user.Mentor == false)
            {
                //defines mentee based on currently logged in user and 
                //includes the mentor relationships
                var mentee = _context.ApplicationUsers
                    .Include(u => u.UserMentors)
                        .ThenInclude(um => um.Mentor)
                    .FirstOrDefault(u => user.Id == u.Id);

                //sets mentor as a variable from data pulled from above
                var mentor = mentee.UserMentors.FirstOrDefault().Mentor;

                var lastMessage = _context.Messages
                    .Where(m => m.SenderId == mentee.Id || m.RecipientId == mentee.Id)
                    .Where(m => m.SenderId == mentor.Id || m.RecipientId == mentor.Id)
                    .OrderByDescending(m => m.TimeStamp)
                    .FirstOrDefault();

                var messagesView = new List<ConversationItem>();
                var conversationItem = new ConversationItem();
                conversationItem.Match = mentor;
                conversationItem.User = mentee;
                conversationItem.RecentMessage = lastMessage;
                conversationItem.IsRead = lastMessage.IsRead;

                messagesView.Add(conversationItem);

                return View(messagesView);

            }
            else
            {
                var mentor = _context.ApplicationUsers
                    .Include(u => u.UserMentees)
                        .ThenInclude(um => um.User)
                    .FirstOrDefault(u => user.Id == u.Id);


                var mentees = mentor.UserMentees.ToList();

                var lastMessages = new List<Messages>();

                foreach (var mentee in mentees)
                {
                    var lastMessage = _context.Messages
                        .Where(m => m.SenderId == mentor.Id || m.RecipientId == mentor.Id)
                        .Where(m => m.SenderId == mentee.UserId || m.RecipientId == mentee.UserId)
                        .OrderByDescending(m => m.TimeStamp)
                        .FirstOrDefault();
                    if (lastMessage != null)
                    {
                        lastMessages.Add(lastMessage);
                    }
                    else
                    {
                        var placeholder = new ApplicationUser();
                        placeholder = mentee.User;
                        
                        lastMessage = new Messages()
                        {
                            RecipientId = mentee.UserId,
                            Recipient = mentee.User,
                            Sender = placeholder, 
                            SenderId = placeholder.Id,
                            Content = "This is a new match! You have not messaged this user yet."
                        };
                        lastMessages.Add(lastMessage);
                    }

                }

                var messagesView = new List<ConversationItem>();
                foreach (var item in lastMessages)
                {
                    var conversationItem = new ConversationItem();
                    conversationItem.User = mentor;
                    if (item.SenderId != user.Id)
                    {
                        conversationItem.Match = item.Sender;
                    }
                    else
                    {
                        conversationItem.Match = item.Recipient;
                    }
                    conversationItem.RecentMessage = item;
                    conversationItem.IsRead = item.IsRead;
                    messagesView.Add(conversationItem);
                }

                return View(messagesView);

            }





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
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();

            var match = await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == id);

            var messages = await _context.Messages
                            .Include(u => u.Sender)
                            .Where(m => m.SenderId == user.Id || m.RecipientId == user.Id)
                            .Where(m => m.SenderId == id || m.RecipientId == id)
                            .OrderBy(m => m.TimeStamp)
                            .ToListAsync();
                        //.Where(m => m.SenderId = user.Id || m.RecipientId = user.Id)
                        //.Where(m => m.SenderId == mentee.UserId || m.RecipientId == mentee.UserId)
                        //.OrderByDescending(m => m.TimeStamp)
                        
            if (messages == null)
            {
                return NotFound();
            }

            var viewModel = new SingleConversation();
            viewModel.Messages = messages;
            viewModel.User = user;
            viewModel.Match = match;

            return View(viewModel);
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
        public async Task<IActionResult> Create(string recipientId, [Bind("MessagesId,SenderId,RecipientId,Content,TimeStamp,IsRead")] SingleConversation messageItem )
        {
            var user = await GetCurrentUserAsync();
            var newMessage = new Messages()
            {
                Content = messageItem.Content,
                RecipientId = recipientId,
                TimeStamp = DateTime.Now,
                SenderId = user.Id,
                IsRead = false
            };
    
            _context.Add(newMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = recipientId });

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
