namespace Shop.Application._Utilities
{
    public class Directories
    {
     
        public static string ProductImaes(string productName)=>$"wwwroor/imaes/products/{productName}";
        public static string ProductImaesGallery(string productName)=>$"wwwroor/imaes/products/{productName}/Gallery";
    }
}
