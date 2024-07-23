using PillReminder.Domain.entities;

namespace PillReminder.Domain.Repositories
{
    public interface IImagesRepository
    {
        Task<bool> RegisterNewImage(ImageEntity image);
        Task<List<ImageEntity>> FindAllImages();
        Task<ImageEntity?> FindImageById(string imageId);
        Task<ImageEntity?> FindImageByRemedyId(string remedyId);

        Task<bool> DeleteImageByRemedyId(string remedyId);
        Task<bool> DeleteImage(string imageId);
    }
}
