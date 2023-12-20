using Microsoft.EntityFrameworkCore;
using Shared.DTO.Core;
using Persistence.Data;
using Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace Services.Core
{
    public class MessageService
    {
        private readonly DatabaseContext _ctx;

        public MessageService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _messages = ctx.Messages;
        }

        private readonly DbSet<Message> _messages;

        public async Task<IEnumerable<MessageDTO>> GetMessages()
        {
            List<Message> messages = await _messages.ToListAsync();
            List<MessageDTO> convertedMessages = new();

            foreach (var message in messages)
            {
                MessageDTO m = new()
                {
                    Id = message.Id,
                    Name = message.Name,
                    LastName = message.LastName,
                    Email = message.Email,
                    Phone = message.Phone,
                    Birthdate = message.Birthdate,
                    Note = message.Note,
                };
                convertedMessages.Add(m);
            }

            return convertedMessages;
        }

        public async Task<MessageDTO> CreateMessage(MessageDTO newMessage)
        {
            _messages.Add(new Message(newMessage.Name, newMessage.LastName, newMessage.Email, newMessage.Phone, newMessage.Birthdate, newMessage.Note));
            await _ctx.SaveChangesAsync();

            return newMessage;
        }

        public async Task DeleteMessage(MessageDTO messageToDelete)
        {
            Message message = await _messages.FindAsync(messageToDelete.Id);
            _messages.Remove(message);
            await _ctx.SaveChangesAsync();
        }
    }
}