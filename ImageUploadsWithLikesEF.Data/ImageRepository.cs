using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ImageUploadsWithLikesEF.Data
{
    public class ImageRepository
    {
        private string _connectionString;
        public ImageRepository(string connectionString)
        {
            _connectionString= connectionString;
        }
        public List<Image> GetImages()
        {
            using var context = new ImageDbContext(_connectionString);
            return context.Images.ToList();
        }
        public void AddImage(Image image)
        {
            using var context = new ImageDbContext(_connectionString);
            context.Images.Add(image);
            context.SaveChanges();

        }
        public Image GetById(int id)
        {
            using var context = new ImageDbContext(_connectionString);
            return context.Images.FirstOrDefault(i => i.Id == id);
        }
        public void LikeImage(int id)
        {
            using var context = new ImageDbContext(_connectionString);
            {
                var image = context.Images.Find(id);
                if (image != null)
                {
                    image.Likes++;
                    context.SaveChanges();
                }
            }
        }
    }
}
