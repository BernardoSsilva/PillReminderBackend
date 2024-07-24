using AutoMapper;
using PillReminder.Communication.remedies.requests;
using PillReminder.Domain;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;
using PillReminderApplication.UseCases.Remedy.Post.Interface;

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
        public async Task Execute(RemedyJsonRequest remedyData)
        {
            Validate(remedyData);

            var newRemedy = _mapper.Map<RemedyEntity>(remedyData);
            await _repository.RegisterNewRemedy(newRemedy);
            await _unitOfWork.Commit();
        }

        private void Validate(RemedyJsonRequest remedyData)
        {

        }
    }
}
