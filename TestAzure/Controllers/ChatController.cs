using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAzure.Models;

namespace TestAzure.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        // Conversas simuladas em memória
        private static List<Conversation> Conversations = new();
        private static List<string> UsersOnline = new() { "alice", "bob", "carol" };

        public IActionResult Index()
        {
            var currentUser = User.Identity?.Name!;
            var otherUsers = UsersOnline.Where(u => u != currentUser).ToList();
            return View(otherUsers);
        }

        [HttpPost]
        public IActionResult Start(string otherUser)
        {
            var currentUser = User.Identity?.Name!;
            var existing = Conversations.FirstOrDefault(c =>
                (c.User1 == currentUser && c.User2 == otherUser) ||
                (c.User2 == currentUser && c.User1 == otherUser));

            if (existing == null)
            {
                existing = new Conversation { User1 = currentUser, User2 = otherUser };
                Conversations.Add(existing);
            }

            return RedirectToAction("Conversation", new { id = existing.Id });
        }

        public IActionResult Conversation(string id)
        {
            var currentUser = User.Identity?.Name!;
            var conversation = Conversations.FirstOrDefault(c => c.Id == id);

            if (conversation == null || !conversation.HasUser(currentUser))
                return Forbid();

            ViewBag.ConversationId = id;
            ViewBag.Peer = conversation.User1 == currentUser ? conversation.User2 : conversation.User1;

            return View();
        }
    }
}
