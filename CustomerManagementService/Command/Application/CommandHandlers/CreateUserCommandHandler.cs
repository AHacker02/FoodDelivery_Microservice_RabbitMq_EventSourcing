using AutoMapper;
using OMF.Common.Models;
using OMF.CustomerManagementService.Command.Application.Command;
using OMF.CustomerManagementService.Command.Application.Event;
using OMF.CustomerManagementService.Command.Application.Repositories;
using RawRabbit;
using ServiceBus.Abstractions;
using System;
using System.Threading.Tasks;

namespace OMF.CustomerManagementService.Command.Application.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUser>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IEventBus _bus;
        private readonly IMapper _map;

        public CreateUserCommandHandler(IAuthRepository authRepository, IEventBus bus, IMapper map)
        {
            _authRepository = authRepository;
            _bus = bus;
            _map = map;
        }
        public async Task HandleAsync(CreateUser command)
        {
            try
            {
                command.Email = command.Email.ToLower();
                if (await _authRepository.UserExists(command.Email))
                {
                    await _bus.PublishEvent(new CustomerEventFailed(command.Email, $"Email: {command.Email} is already in use", "user_already_exists"));
                }

                var userToCreate = _map.Map<User>(command);

                var createdUser = await _authRepository.Register(userToCreate, command.Password);

                await _bus.PublishEvent(new UserCreated(createdUser.Email, command.Id));
            }
            catch (Exception ex)
            {
                await _bus.PublishEvent(new CustomerEventFailed(command.Email, $"Message: {ex.Message} Stacktrace: {ex.StackTrace}", "system_exception"));
            }
        }
    }
}
