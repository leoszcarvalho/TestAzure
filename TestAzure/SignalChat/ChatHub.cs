using Microsoft.AspNetCore.SignalR;

namespace TestAzure.SignalChat
{
    public class ChatHub : Hub
    {
        public async Task JoinConversation(string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
        }

        public async Task SendMessageToConversation(string conversationId, string message)
        {
            var username = Context.User.Identity?.Name ?? "Anônimo";
            await Clients.Group(conversationId).SendAsync("ReceiveMessage", username, message);
        }
    }

}