using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EFArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogContext context = new BlogContext();
        public List<Article> GetArticlesByWriter(int id)
        {
            //ArticleDal içerisinde tanımlanan metodun içi burada dolduruluyor.
            var values = context.Articles.Where(x => x.AppUser.Id == id).Include(x => x.Category).Include(x => x.Comments).Include(x => x.AppUser).ToList();
            return values;
        }

        public List<Article> GetAppUserInfoByArticleId(int id)
        {
            var values = context.Articles.Include(x => x.AppUser).Where(x => x.ArticleId == id).ToList();
            return values;
        }
        public List<Article> GetArticlesWithCategory()
        {
            var values = context.Articles.Include(x => x.Category).Include(x => x.Comments).Include(x => x.AppUser).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategoryByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).Include(x => x.Category).ToList(); //Include kullanarak articlea categorileri dahil etmiş oluyoruz.
            return values;
        }

        public Article GetArticleWithCategoryByArticleId(int id)
        {
            var values = context.Articles.Where(x => x.CategoryId == id).Include(y => y.Category).FirstOrDefault();
            return values;
        }

        public int CommentsCountByArticle(int id)
        {
            var values = context.Comments.Where(x => x.Article.ArticleId == id).Count();
            return values;
        }
        //Okuma süresi için 
        public int GetReadingTime(int id)
        {
            // Belirli bir makale Id'sine sahip makaleyi veritabanından al
            var article = context.Articles.FirstOrDefault(a => a.ArticleId == id);

            // Eğer makale bulunursa, kelime sayısını hesapla
            if (article != null)
            {
                // Metindeki boşlukları ve noktalama işaretlerini temizle
                string cleanText = System.Text.RegularExpressions.Regex.Replace(article.Detail, @"[\W_]+", " ");

                // Metni boşluklardan ayırarak kelime sayısını hesapla
                string[] words = cleanText.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                // Kelime sayısını döndür

                int wordCount = words.Length;
                int readingTime = wordCount / 217; // 217 kelime için 1 dakika
                                                   // Eğer kalan kelime sayısı varsa, bir dakika ekleyelim
                if (wordCount % 217 != 0)
                {
                    readingTime++;
                }

                return readingTime; // Okuma süresini döndür

            }

            // Makale bulunamazsa veya içerik boşsa, kelime sayısını 0 olarak döndür
            return 0;
        }
        public Article GetCategoryNameByArticleId(int id)
        {
            var values = context.Articles.Where(x => x.ArticleId == id).Include(x => x.AppUser).Include(x => x.Category).FirstOrDefault();
            return values;
        }
        public List<Article> GetArticlesByCategoryId(int id)
        {
            var values = context.Articles.Where(x => x.CategoryId == id).Include(x => x.Category).Include(x => x.AppUser).Include(x => x.Comments).ToList();
            return values;
        }
        //Liste türünde okuma sürelerini hesaplatıyorum.
        public List<int> GetReadingTimeAll()
        {
            // Belirli bir makale Id'sine sahip makaleyi veritabanından al
            var article = context.Articles.ToList();
            //int liste oluşturup alacağım liste değerini buna dolduracağım.
            List<int> readingTimes = new List<int>();

            foreach (var item in article)
            {
                string cleanText = System.Text.RegularExpressions.Regex.Replace(item.Detail, @"[\W_]+", " ");
                // Metni boşluklardan ayırarak kelime sayısını hesapla
                string[] words = cleanText.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

                // Kelime sayısını bul
                int wordCount = words.Length;

                // Okuma süresini hesapla
                int readingTime = wordCount / 217; // 217 kelime için 1 dakika
                                                   // Eğer kalan kelime sayısı varsa, bir dakika ekleyelim
                if (wordCount % 217 != 0)
                {
                    readingTime++;
                }

                // Okuma süresini listeye ekle
                readingTimes.Add(readingTime);
            }

            // Okuma sürelerini döndür
            return readingTimes;
        }
        public List<Article> GetFeaturePost()
        {
            var valeus = context.Articles.Where(x => x.IsFeaturePost == true).Include(x => x.Category).Include(x => x.AppUser).ToList();
            return valeus;
        }
        public Article ChangeIsApprovedArticleById(int id)
        {
            var values = context.Articles.Find(id);
            if (values.IsApproved == false)
            {
                values.IsApproved = true;
            }
            else
            {
                values.IsApproved= false;
            }
            context.SaveChanges();
            return values;
        }
        public Article ChangeIsFeaturePostArticleById(int id)
        {
            var values = context.Articles.Find(id);
            if (values.IsFeaturePost == false)
            {
                values.IsFeaturePost = true;
            }
            else
            {
                values.IsFeaturePost = false;
            }
            context.SaveChanges();
            return values;
        }
    }
}
