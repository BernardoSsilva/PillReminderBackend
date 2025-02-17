﻿using AutoMapper;
using PillReminder.Comunication.users.Requests;
using PillReminder.Domain;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;
using PillReminder.Exception.exceptions;
using PillReminder.JWTAdmin.services;
using PillReminderApplication.UseCases.User.Put.Interfaces;
using PillReminderApplication.Validators;

namespace PillReminderApplication.UseCases.User.Put
{
    public class UpdateUserDataUseCase : IUpdateUserDataUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;

        public UpdateUserDataUseCase(IMapper mapper, IUnitOfWork unitOfWork, IUserRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task Execute( UserJsonRequest requestData, string token)
        {
            var tokenAdmin = new AdminToken();

            tokenAdmin.ValidateToken(token);

            var decodedToken = tokenAdmin.DecodeToken(token);

            Validate(requestData);


            var user = await _repository.FindUserById(decodedToken.UserId.ToString());


            if (user is null)
            {
                throw new NotFoundException("User not found");
            }


            var newUserData = _mapper.Map(requestData, user);
            newUserData.UpdatedAt = DateTime.UtcNow;
            _repository.UpdateUser(newUserData);

            await _unitOfWork.Commit();
        }

        private void Validate(UserJsonRequest requestData)
        {
            var validator = new UserValidator();
            var result = validator.Validate(requestData);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ValidationErrorsException(errorMessages);
            }
        }
    }
}
