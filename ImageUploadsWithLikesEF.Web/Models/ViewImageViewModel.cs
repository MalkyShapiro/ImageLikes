using ImageUploadsWithLikesEF.Data;

namespace ImageUploadsWithLikesEF.Web.Models
{
    public class ViewImageViewModel
    {
        public Image Image { get; set; }
        public bool Alreadyliked { get; set; }
    }
}
