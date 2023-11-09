using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextToolkitTests
{
    public class MarkdownParserTests
    {
        [Fact]
        public void Parse_ShouldReturnEmptyString_WhenGivenEmptyString()
        {
            // Arrange
            var parser = new TextToolkit.MarkdownParser();

            // Act
            var result = parser.Parse("");

            // Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Parse_ShouldReturnSameString_WhenGivenStringWithoutMarkdown()
        {
            // Arrange
            var parser = new TextToolkit.MarkdownParser();
            var input = "This is a test string.";

            // Act
            var result = parser.Parse(input);

            // Assert
            Assert.Equal(input, result);
        }

        [Fact]
        public void Parse_ShouldReturnParsedString_WhenGivenStringWithMarkdown()
        {
            // Arrange
            var parser = new TextToolkit.MarkdownParser();
            var input = "# Header 1\n## Header 2\n### Header 3\n---\n> Blockquote\n* List Item\n**Bold**\n*Italic*\n![Alt Text](https://example.com/image.png)\n[Link Text](https://example.com)";

            // Act
            var result = parser.Parse(input);

            // Assert
            Assert.Equal("<h1>Header 1</h1>\n<h2>Header 2</h2>\n<h3>Header 3</h3>\n<hr>\n<blockquote>Blockquote</blockquote>\n<li>List Item</li>\n<strong>Bold</strong>\n<em>Italic</em>\n<img src=\"https://example.com/image.png\" alt=\"Alt Text\">\n<a href=\"https://example.com\">Link Text</a>", result);
        }


        [Fact]
        public void Parse_ShouldHandleMultipleMarkdownPatternsInMultipleLines()
        {
            // Arrange
            var parser = new TextToolkit.MarkdownParser();
            var input = "* List Item\n**Bold**\n*Italic*";

            // Act
            var result = parser.Parse(input);

            // Assert
            Assert.Equal("<li>List Item</li>\n<strong>Bold</strong>\n<em>Italic</em>", result);
        }

        [Fact]
        public void Parse_ShouldHandleMultipleMarkdownPatternsInMultipleLinesWithOtherText()
        {
            // Arrange
            var parser = new TextToolkit.MarkdownParser();
            var input = "This is a test string.\n* List Item\n**Bold**\n*Italic*\nThis is another test string.";

            // Act
            var result = parser.Parse(input);

            // Assert
            Assert.Equal("This is a test string.\n<li>List Item</li>\n<strong>Bold</strong>\n<em>Italic</em>\nThis is another test string.", result);
        }
    }
}
