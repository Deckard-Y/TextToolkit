using System;
using TextToolkit;

namespace MyApp
{
    public static class Program
    {
        public static void Main()
        {
            string brokenHtml = "This is <b>bold and <i>italic text";
            string fixedHtml = HtmlFixer.FixBrokenHtml(brokenHtml);
            Console.WriteLine(fixedHtml);

            var rn = new FantasyNameGenerator();
            Console.WriteLine(rn.GenerateName());

            //var parser = new MarkdownParser();
            //var markdown = "# Heading\nSome text";
            //var html = parser.Parse(markdown);
            //Console.WriteLine(html);


            var parser = new MarkdownParser();
            var markdown = "* List item 1\n* List item 2\n* List item 3";
            var html = parser.Parse(markdown);
            Console.WriteLine(html);

            var configManager = new ConfigurationManager<AppSettings>("AppSettings.json");
            configManager.Load(); // 設定を読み込む

            Console.WriteLine(configManager.Settings.ApplicationName);

            // 設定を変更する
            configManager.Settings.ApplicationName = "Updated App";
            configManager.Settings.MaintenanceMode = true;
            configManager.Save(); // 変更をファイルに書き込む
            Console.WriteLine(configManager.Settings.ApplicationName);
        }
    }
}