using PillReminder.Domain.entities;

namespace PillReminder.Domain.Repositories
{
    public interface IImagesRepository
    {
        Task RegisterNewImage(ImageEntity image);
        Task<List<ImageEntity>> FindAllImages();
        Task<ImageEntity> FindImageById(string imageId);
        Task<ImageEntity> FindImageByRemedyId(string remedyId);
        Task DeleteImage(ImageEntity image);
    }
}
