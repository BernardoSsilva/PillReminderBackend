using AutoMapper;
using PillReminder.Communication.remedies.responses;
using PillReminder.Domain.Repositories;
using PillReminder.Exception.exceptions;
using PillReminder.JWTAdmin.services;
using PillReminderApplication.UseCases.Remedy.Get.interfaces;

namespace PillReminderApplication.UseCases.Remedy.Get
{
    public class FindRemedyByIdUseCase : IFindRemedyByIdUseCase
    {
        private readonly IRemedyRepository _repository;
        private readonly IMapper _mapper;

        public FindRemedyByIdUseCase(IRemedyRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<RemedyDetailedJsonResponse> Execute(string remedyId, string token)
        {
            var jwtAdmin = new AdminToken();
            jwtAdmin.ValidateToken(token);

            var dedcodedToken = jwtAdmin.DecodeToken(token);
            var result = await _repository.SearchRemedyDetails(remedyId, dedcodedToken.UserId);

            if(result is null)
            {
                throw new NotFoundException("remedy not found");
            }

            return _mapper.Map<RemedyDetailedJsonResponse>(result);
        }
    }
}
