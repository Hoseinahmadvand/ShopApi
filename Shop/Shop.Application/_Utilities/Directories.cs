namespace Shop.Application._Utilities
{
    public class Directories
    {
     
        public static string ProductImages(string productName)=>$"wwwroot/images/products/{productName}";
        public static string ProductImagesGallery(string productName)=>$"wwwroot/images/products/{productName}/Gallery";

        public const string SliderImages="wwwroot/images/slider";
        public const string BannerImages="wwwroot/images/banner";


        public const string UserAvatarImages="wwwroot/images/users/avatars";
    }
}
