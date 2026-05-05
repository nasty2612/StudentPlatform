using StudentPlatform.Domain.Entities;
using StudentPlatform.Models;

namespace StudentPlatform.Infrastructure
{
    public static class HelperDTO
    {
        // Превращает Service в ServiceDTO
        public static ServiceDTO TransformService(Service entity)
        {
            ServiceDTO entityDTO = new ServiceDTO();
            entityDTO.Id = entity.Id;
            entityDTO.CategoryName = entity.serviceCategory?.Title;
            entityDTO.Title = entity.Title;
            entityDTO.DescriptionShort = entity.DescriptionShort;
            entityDTO.Description = entity.Description;
            entityDTO.PhotoFileName = entity.Photo;
            entityDTO.Type = entity.Type.ToString();

            return entityDTO;
        }

        public static IEnumerable<ServiceDTO> TransformServices(IEnumerable<Service> entities)
        {
            List<ServiceDTO> entitiesDTO = new List<ServiceDTO>();
            //B цикле каждую доменную модель из коллекции превращаем B DTO
            foreach (Service entity in entities)
                entitiesDTO.Add(TransformService(entity));
            return entitiesDTO;
        } // 23.20
    }
}