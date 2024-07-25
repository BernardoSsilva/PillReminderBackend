using PillReminder.Domain;
using PillReminder.Domain.Repositories;
using PillReminder.JWTAdmin.services;
using PillReminderApplication.UseCases.Remedy.Delete.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillReminderApplication.UseCases.Remedy.Delete
{
    public class DeleteRemedyUseCase : IDeleteRemedyUseCase
    {
        private readonly IRemedyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRemedyUseCase(IRemedyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(string remedyId, string token)
        {
            var jwtAdmin = new AdminToken();
            jwtAdmin.ValidateToken(token);

            var decodedToken = jwtAdmin.DecodeToken(token);

            await _repository.DeleteRemedy(remedyId, decodedToken.UserId);
            await _unitOfWork.Commit();
        }
    }
}
