using CSMA_API.Domain;
using System.Collections.Generic;

namespace CSMA_API.Services
{
    public interface IServicesService
    {
        List<Service> GetAll();
        Service GetById(int id);
        bool UpdateService(Service serviceToUpdate);

    }
}
