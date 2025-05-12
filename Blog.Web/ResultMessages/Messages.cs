﻿namespace Blog.Web.ResultMessages
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
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} Başlıklı Makale Başarıyla geri alınmıştır.";
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
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} Email Adresli Kullanıcı Başarıyla Eklendi.";
            }
            public static string Update(string userName)
            {
                return $"{userName} Email Adresli Kullanıcı Başarıyla Güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} Email Adresli Kullanıcı Başarıyla Silinmiştir.";
            }
        }
        
     
    }
}
