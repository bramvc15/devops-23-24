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
                    Read = message.Read,
                };
                convertedMessages.Add(m);
            }

            return convertedMessages;
        }

        public async Task<MessageDTO> CreateMessage(MessageDTO newMessage)
        {
            _messages.Add(new Message(newMessage.Name, newMessage.LastName, newMessage.Email, newMessage.Phone, newMessage.Birthdate, newMessage.Note, newMessage.Read));
            await _ctx.SaveChangesAsync();

            return newMessage;
        }

        public async Task<MessageDTO> UpdateMessage(MessageDTO updatedMessage)
        {
            Message message = await _messages.FindAsync(updatedMessage.Id);
            message.UpdateMessage(updatedMessage.Name, updatedMessage.LastName, updatedMessage.Email, updatedMessage.Phone, updatedMessage.Birthdate, updatedMessage.Note, updatedMessage.Read);
            _messages.Update(message);
            await _ctx.SaveChangesAsync();

            return updatedMessage;
        }

        public async Task DeleteMessage(int? messageToDelete)
        {
            Message message = await _messages.FindAsync(messageToDelete);
            _messages.Remove(message);
            await _ctx.SaveChangesAsync();
        }
    }
}