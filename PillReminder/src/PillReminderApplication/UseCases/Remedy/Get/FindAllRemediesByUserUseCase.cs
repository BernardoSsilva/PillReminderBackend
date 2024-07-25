using AutoMapper;
using PillReminder.Communication.remedies.responses;
using PillReminder.Domain.Repositories;
using PillReminder.JWTAdmin.services;
using PillReminderApplication.UseCases.Remedy.Get.interfaces;

namespace PillReminderApplication.UseCases.Remedy.Get
{
    public class FindAllRemediesByUserUseCase : IFindAllRemediesByUserUseCase
    {
        private readonly IRemedyRepository _repository;
        private readonly IMapper _mapper;

        public FindAllRemediesByUserUseCase(IRemedyRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<MultiplesRemediesJsonResponse> Execute(string token)
        {
            var jwtAdmin = new AdminToken();
            jwtAdmin.ValidateToken(token);

            var decodedToken = jwtAdmin.DecodeToken(token);

            var result = await _repository.FindAllRemedies(decodedToken.UserId);

            return new MultiplesRemediesJsonResponse
            {
                remedies = _mapper.Map<List<RemedyShortJsonResponse>>(result)
            };
        }
    }
}
