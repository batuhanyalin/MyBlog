namespace MyBlog.PresentationLayer.Models
{
    using HtmlAgilityPack;
    using System;
    using System.Text;


    public static class CustomHtmlHelper
    {
        public static string GetPlainTextFromHtml(string html, int maxLength)
        {
            if (string.IsNullOrEmpty(html)) return string.Empty;

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var textBuilder = new System.Text.StringBuilder();
            foreach (var node in doc.DocumentNode.SelectNodes("//text()"))
            {
                textBuilder.Append(node.InnerText);
                if (textBuilder.Length > maxLength)
                {
                    textBuilder.Append("...");
                    break;
                }
            }

            return textBuilder.ToString().Substring(0, Math.Min(textBuilder.Length, maxLength));
        }
    }
}
