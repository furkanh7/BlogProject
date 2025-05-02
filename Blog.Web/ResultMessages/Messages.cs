namespace Blog.Web.ResultMessages
{
    public class Messages
    {

        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} Başlıklı Makale Başarıyla Eklendi.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} Başlıklı Makale Başarıyla Güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} Başlıklı Makale Başarıyla Silinmiştir.";
            }
        }
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} Başlıklı Kategori Başarıyla Eklendi.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} Başlıklı Kategori Başarıyla Güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} Başlıklı Kategori Başarıyla Silinmiştir.";
            }
        }
     
    }
}
