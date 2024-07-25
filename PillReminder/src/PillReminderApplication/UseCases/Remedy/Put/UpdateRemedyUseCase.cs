using AutoMapper;
using Microsoft.VisualBasic;
using PillReminder.Communication.remedies.requests;
using PillReminder.Domain;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;
using PillReminder.Exception.exceptions;
using PillReminder.JWTAdmin.services;
using PillReminderApplication.UseCases.Remedy.Put.Interfaces;
using PillReminderApplication.Validators;

namespace PillReminderApplication.UseCases.Remedy.Put
{
    internal class UpdateRemedyUseCase : IUpdateRemedyUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRemedyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRemedyUseCase(IMapper mapper, IRemedyRepository repository, IUnitOfWork unitOfWork )
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(RemedyJsonRequest requestData,string remedyId, string token)
        {
            var jwtAdmin = new AdminToken();
            jwtAdmin.ValidateToken(token);

            var decodedToken = jwtAdmin.DecodeToken(token);

            var remedyToEdit = await _repository.SearchRemedyDetails(remedyId, decodedToken.UserId);

            if(remedyToEdit is null)
            {
                throw new NotFoundException("Remedy not found");
            }

            var newRemedyData =  _mapper.Map(remedyToEdit, requestData);
            _repository.UpdateRemedyData(_mapper.Map<RemedyEntity>(newRemedyData));
            await _unitOfWork.Commit();


        }

        private void Validate(RemedyJsonRequest request)
        {
            var validator = new RemedyValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ValidationErrorsException(errorMessages);
            }
        }
    }
}
