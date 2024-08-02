using AutoMapper;
using PillReminder.Communication.remedies.requests;
using PillReminder.Communication.remedies.responses;
using PillReminder.Domain;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;
using PillReminder.Exception.exceptions;
using PillReminder.JWTAdmin.services;
using PillReminderApplication.UseCases.Remedy.Post.Interface;
using PillReminderApplication.Validators;

namespace PillReminderApplication.UseCases.Remedy.Post
{
    public class CreateNewRemedyUseCase : ICreateNewRemedyUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRemedyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateNewRemedyUseCase(IMapper mapper, IRemedyRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RemedyShortJsonResponse> Execute(RemedyJsonRequest remedyData, string token)
        {
            var jwtAdmin = new AdminToken();

            jwtAdmin.ValidateToken(token);
            Validate(remedyData);


            var decodedToken = jwtAdmin.DecodeToken(token);
            var newRemedy = new RemedyEntity
            {
                RemedyDosage = remedyData.RemedyDosage,
                UserId = decodedToken.UserId,
                RemedyName = remedyData.RemedyName,
                ScheduledHours = remedyData.ScheduledHours,
                UsagePeriod = remedyData.UsagePeriod,
                CreatedAt = DateTime.UtcNow
            };


            await _repository.RegisterNewRemedy(newRemedy);
            await _unitOfWork.Commit();

            return _mapper.Map<RemedyShortJsonResponse>(newRemedy);
        }

        private void Validate(RemedyJsonRequest remedyData)
        {
            var validator = new RemedyValidator();
            var result = validator.Validate(remedyData);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ValidationErrorsException(errorMessages);
            }
            
        }
    }
}
