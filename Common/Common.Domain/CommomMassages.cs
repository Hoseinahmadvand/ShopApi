namespace Common.Domain
{
    public class CommomMassages
    {
        public static string DuplicatedRecord(string fieldName) =>
            $"امکان ثبت {fieldName} تکراری وجود ندارد. لطفا مجدد تلاش بفرمایید.";

        public static string RecordNotFound(string fieldName) =>
            $"{fieldName} با اطلاعات درخواست شده یافت نشد. لطفا مجدد تلاش بفرمایید.";
        
        public static string NotValid(string fieldName) =>
            $"{fieldName} نا معتبر است .لطفا دوباره تلاش کنید ";



    }
}
