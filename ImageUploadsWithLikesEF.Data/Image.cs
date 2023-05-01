using Microsoft.Data.SqlClient.DataClassification;

namespace ImageUploadsWithLikesEF.Data
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public DateTime UploadedAt { get; set; }
        public int Likes { get; set; }
    }
}