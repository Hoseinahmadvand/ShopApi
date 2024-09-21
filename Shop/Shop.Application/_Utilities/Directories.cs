namespace Shop.Application._Utilities
{
    public class Directories
    {
     
        public static string ProductImaes(string productName)=>$"wwwroor/images/products/{productName}";
        public static string ProductImaesGallery(string productName)=>$"wwwroor/images/products/{productName}/Gallery";

        public const string SliderImages="wwwroor/images/Slider";
        public const string BannerImages="wwwroor/images/Slider";
    }
}
