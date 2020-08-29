using AutoMapper;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Models.DtoModels;
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
        private readonly IMapper _mapper;

        public ClientsBusinessLogic(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ClientsDto> CreateClient(Clients client)
        {
            try
            {
                _logger.LogInformation($"Envoke method {MethodBase.GetCurrentMethod().Name}");

                _unitOfWork.Clients.Add(client);
                _unitOfWork.Complete();

                var clientsDTO = _mapper.Map<Clients, ClientsDto>(client);

                return clientsDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }

        public async Task<IEnumerable<ClientsDto>> GetAllClients()
        {
            try
            {
                var clients = _unitOfWork.Clients.GetAll()
                    .Where(x => x.Deleted.Equals(false))
                    .OrderBy(o => o.Name)
                    .ToList();

                _unitOfWork.Complete();

                var clientsDTO = _mapper.Map<List<Clients>, List<ClientsDto>>(clients);

                return clientsDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }

        public async Task<ClientsDto> GetClientById(Guid id)
        {
            try
            {
                var client = _unitOfWork.Clients.GetById(id);
                _unitOfWork.Complete();

                var clientDto = _mapper.Map<Clients, ClientsDto>(client);

                return clientDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }

        public async Task<bool> SoftDeleteClient(Guid id)
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
