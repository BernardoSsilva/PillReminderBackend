using AutoMapper;
using PillReminder.Domain.Repositories;
using PillReminder.Domain;
using PillReminderApplication.UseCases.User.Delete.Interfaces;
using PillReminder.Infrastructure;
using PillReminder.Exception.exceptions;

namespace PillReminderApplication.UseCases.User.Delete
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public DeleteUserUseCase(IUnitOfWork unitOfWork, IUserRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(string userId)
        {
            var user = await _repository.FindUserById(userId);
            if (user is null)
            {
                throw new NotFoundException("user not found");
            }
            await _repository.DeleteUser(userId);
            await _unitOfWork.Commit();
        }
    }
}
