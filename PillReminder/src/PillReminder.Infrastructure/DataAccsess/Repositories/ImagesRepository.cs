using Microsoft.EntityFrameworkCore;
using PillReminder.Domain.entities;
using PillReminder.Domain.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace PillReminder.Infrastructure.Repositories
{
    internal class ImagesRepository : IImagesRepository
    {
        private readonly PillReminderDbAccess _dbAccess;

        public ImagesRepository(PillReminderDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        // register image

        public async Task<bool> RegisterNewImage(ImageEntity image)
        {
            await DeleteImageByRemedyId(image.RemedyId);
            await _dbAccess.Images.AddAsync(image);
            return true;
        }

        // delete image
        public async Task<bool> DeleteImage(string imageId)
        {
            var imageToDelete = await _dbAccess.Images.FirstOrDefaultAsync(image => image.Id == imageId);
            if (imageToDelete is null)
            {
                return false;
            }
            _dbAccess.Images.Remove(imageToDelete);
            return true;
        }


        // find all images
        public async Task<List<ImageEntity>> FindAllImages()
        {
            var imagesList = await _dbAccess.Images.AsNoTracking().ToListAsync();
            return imagesList;
        }

        // find image by id


        public async Task<ImageEntity?> FindImageById(string imageId)
        {
            var image = await _dbAccess.Images.AsNoTracking().FirstOrDefaultAsync(image => image.Id == imageId);
            return image;
        }

        // find image by remedy id
        public Task<ImageEntity?> FindImageByRemedyId(string remedyId)
        {
            throw new NotImplementedException();
        }


        // delete image by remedy id
        public async Task<bool> DeleteImageByRemedyId(string remedyId)
        {
            var imageToDelete = await _dbAccess.Images.FirstOrDefaultAsync(image => image.RemedyId == remedyId);
            if (imageToDelete is null)
            {
                return false;
            }

            return true;
        }
    }
}
