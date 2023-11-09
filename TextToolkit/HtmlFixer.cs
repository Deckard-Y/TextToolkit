using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextToolkit
{
    public static class HtmlFixer
    {
        public static string FixBrokenHtml(string html)
        {
            var tagStack = new Stack<string>();
            var tags = new Regex(@"</?(\w+)[^>]*>", RegexOptions.Compiled);

            foreach (Match match in tags.Matches(html))
            {
                string tag = match.Value;

                if (!tag.StartsWith("</"))
                {
                    string tagName = tag.Split(new[] { ' ', '>' }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(1);
                    tagStack.Push(tagName);
                }
                else
                {
                    string tagName = tag.Split(new[] { '<', '/', '>' }, StringSplitOptions.RemoveEmptyEntries)[0];

                    if (tagStack.Count > 0 && tagStack.Peek() == tagName)
                    {
                        tagStack.Pop();
                    }
                    else
                    {
                        html = html.Insert(match.Index, $"<{tagName}>");
                    }
                }
            }

            while (tagStack.Count > 0)
            {
                html += $"</{tagStack.Pop()}>";
            }

            return html;
        }
    }
}