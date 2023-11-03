using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextToolkit
{
    public class MarkdownParser
    {
        private static readonly Dictionary<string, string> patterns = new Dictionary<string, string>
        {
            { @"^# (.+)$", "<h1>$1</h1>" },
            { @"^## (.+)$", "<h2>$1</h2>" },
            { @"^### (.+)$", "<h3>$1</h3>" },

            // Markdown Parser
            { @"^---$", "<hr>" },
            { @"^> (.+)$", "<blockquote>$1</blockquote>" },

            { @"^\* (.+)$", "<li>$1</li>" },

            // Bold and Italic
            { @"^\*\*(.+)\*\*$", "<strong>$1</strong>" },
            { @"^\*(.+)\*$", "<em>$1</em>" },

            // Images and Links
            { @"^\!\[(.+)\]\((.+)\)$", "<img src=\"$2\" alt=\"$1\">" },
            { @"^\[(.+)\]\((.+)\)$", "<a href=\"$2\">$1</a>" },
        };


        public string Parse(string markdown)
        {
            var lines = markdown.Split(new[] { "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                foreach (var pattern in patterns)
                {
                    if (Regex.IsMatch(lines[i], pattern.Key))
                    {
                        lines[i] = Regex.Replace(lines[i], pattern.Key, pattern.Value);
                        break;
                    }
                }
            }

            return string.Join("\n", lines);
        }
    }
}