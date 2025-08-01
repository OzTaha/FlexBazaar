﻿using AutoMapper;
using FlexBazaar.Message.DAL.Context;
using FlexBazaar.Message.DAL.Entities;
using FlexBazaar.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FlexBazaar.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;
        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            /* await _messageContext.UserMessages.AddAsync(createMessageDto);   */
            var value = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(value);
            await _messageContext.SaveChangesAsync();

        }
        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);
            await _messageContext.SaveChangesAsync();
        }
        public async Task<List<ResultMessageDto>> GetAllMessageAysnc()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }
        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(values);
        }
        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAysnc(string id)
        {
             var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAysnc(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }
        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<UserMessage>(updateMessageDto);
             _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }
    }
}
