using AutoMapper;
using OMF.Common.Models;
using OMF.CustomerManagementService.Command.Application.Event;
using OMF.CustomerManagementService.Command.Application.Repositories;
using RawRabbit;
using ServiceBus.Abstractions;
using System;
using System.Threading.Tasks;

namespace OMF.CustomerManagementService.Command.Application.EventHandlers
{
    public class DeleteUserEventHandler : IEventHandler<DeleteUser>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IBusClient _bus;
        private readonly IMapper _map;

        public DeleteUserEventHandler(IAuthRepository authRepository, IBusClient bus, IMapper map)
        {
            _authRepository = authRepository;
            _bus = bus;
            _map = map;
        }
        public async Task HandleAsync(DeleteUser command)
        {
            try
            {
                command.Email = command.Email.ToLower();
                if (!await _authRepository.UserExists(command.Email))
                {
                    await _bus.PublishAsync(new CustomerEventFailed(command.Email, $"Email: {command.Email} is not present in the system", "user_doesn't_exists"));
                }

                var userToDelete = _map.Map<User>(command);

                await _authRepository.DeleteUser(userToDelete, command.Password);

            }
            catch (Exception ex)
            {
                await _bus.PublishAsync(new CustomerEventFailed(command.Email, $"Message: {ex.Message} Stacktrace: {ex.StackTrace}", "system_exception"));
            }
        }
    }
}
