using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextToolkit
{
    public class MarkdownParser
    {
        private static readonly Dictionary<string, string> patterns = new Dictionary<string, string>
        {
            // Headers
            { @"^# (.+)$", "<h1>$1</h1>" },
            { @"^## (.+)$", "<h2>$1</h2>" },
            { @"^### (.+)$", "<h3>$1</h3>" },

            // Horizontal Rule
            { @"^---$", "<hr>" },
            { @"^> (.+)$", "<blockquote>$1</blockquote>" },

            // Bold and Italic
            { @"(?<!\*)\*\*(.+?)\*\*(?!\*)", "<strong>$1</strong>" }, // Make non-greedy
            { @"(?<!\*)\*(.+?)\*(?!\*)", "<em>$1</em>" }, // Make non-greedy

            // Images and Links
            { @"!\[(.+?)\]\((.+?)\)", "<img src=\"$2\" alt=\"$1\">" }, // Make non-greedy and remove line start anchor
            { @"\[(.+?)\]\((.+?)\)", "<a href=\"$2\">$1</a>" }, // Make non-greedy and remove line start anchor

            // List items
            { @"^(?<!\*)\* (.+)$", "<li>$1</li>" }, // Add line start anchor to match start of line

            // Multiple Markdown Patterns in Single Line
            { @"(?<=\s|^)(\*|\d+\.)\s(.+?)(?=\s+(\*|\d+\.)\s|\s*$)", "<li>$2</li>" },
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