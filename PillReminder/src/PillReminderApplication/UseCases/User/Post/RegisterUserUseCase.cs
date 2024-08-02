using AutoMapper;
using MD5Hash;
using PillReminder.Comunication.users.Requests;
using PillReminder.Comunication.users.Responses;
using PillReminder.Domain;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;
using PillReminder.Exception.exceptions;
using PillReminderApplication.UseCases.User.Post.Interfaces;
using PillReminderApplication.Validators;

namespace PillReminderApplication.UseCases.User.Post
{

    public class RegisterUserUseCase:IRegisterUserUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IUnitOfWork unitOfWork, IUserRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserShortJsonResponse> Execute(UserJsonRequest user)
        {
            Validate(user);
            user.Password = user.Password.ToString().GetMD5();
            

            var insertData = _mapper.Map<UserEntity>(user);

            insertData.CreatedAt = DateTime.UtcNow;

            Console.WriteLine(insertData);

            await _repository.RegisterNewUser(insertData);
            await _unitOfWork.Commit();
            return  _mapper.Map<UserShortJsonResponse>(insertData);
        }

        private void Validate(UserJsonRequest user)
        {
            var validator = new UserValidator();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ValidationErrorsException(errorMessages);
            }
        }
    }
}
