using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Models.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BusinessManager.Shared.BusinessLogic
{
    public class ClientsBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ClientsBusinessLogic(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Clients> CreateClient(Clients client)
        {
            try
            {
                _unitOfWork.Clients.Add(client);
                _unitOfWork.Complete();

                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<Clients>> GetAllClients()
        {
            try
            {
                var clients = _unitOfWork.Clients.GetAll()
                    .Where(x => x.Deleted.Equals(0))
                    .ToList();

                _unitOfWork.Complete();

                return clients;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteClient(Guid id)
        {
            try
            {
                var isDeleted = _unitOfWork.Clients.DeleteClient(id);

                return isDeleted;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }

        public void UpdateClient(Guid id, Clients client)
        {
            try
            {
                _unitOfWork.Clients.UpdateClient(id, client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }
    }
}
