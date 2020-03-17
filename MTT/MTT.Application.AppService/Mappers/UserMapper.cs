using MTT.Application.AppService.Contracts.Messages;
using MTT.Application.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MTT.Application.AppService.Mappers
{
    public class UserMapper : IDisposable
    {
        public GetUseMessage ToUserMessageByToken(User model, GetUseMessage message, string token) 
        {
            message.Id = model.Id;
            message.Email = model.Email;
            message.Name = model.Name;
            message.Token = token;

            return message;
        }
        public GetUseMessage ToUserMessage(User model, GetUseMessage message)
        {
            message.Id = model.Id;
            message.Email = model.Email;
            message.Name = model.Name;
            
            return message;
        }
        public List<ListUserMessage> ToListUserMessage(List<User> users) 
        {
            List<ListUserMessage> listUserMessage = new List<ListUserMessage>();

            listUserMessage = users.
                              Select(model => new ListUserMessage { Id = model.Id, Email = model.Email, Name = model.Name }).
                              ToList();

            return listUserMessage;
        }

        public void Dispose()
        {
            
        }
    }
}
