using CSMA_API.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CSMA_API.Services
{
    public class ServicesService : IServicesService
    {
        private readonly List<Service> _services;

        public ServicesService()
        {
            _services = new List<Service>();
            for (int i = 0; i < 9; i++)
            {
                _services.Add(new Service { Id = i, Name = "Masaj" + i, Price = i * 20, Duration = i * 10, Description = "Title" + i });
            }
        }


        public List<Service> GetAll()
        {
            return _services;
        }

        public Service GetById(int id)
        {
            return _services.FirstOrDefault(service => service.Id == id);
        }

        public bool UpdateService(Service serviceToUpdate)
        {
            bool postExists = GetById(serviceToUpdate.Id) != null;

            if (!postExists)
            {
                return false;
            }

            var index = _services.FindIndex(x => x.Id == serviceToUpdate.Id);
            _services[index] = serviceToUpdate;

            return true;
        }
    }
}
