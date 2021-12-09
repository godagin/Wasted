using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;

namespace WebWasted.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {

        }

        public async Task SendGroupMessage(String roomID, String user, String message)
        {
            await Clients.Group(roomID).SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinRoom(String roomID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomID);
        }
    }
}