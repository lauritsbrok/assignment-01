using Xunit;

namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void Given_Many_Strings_Return_1_Long_String()
    {
        // Given
        var input = new List<string>{"There is nothing proper about what you are doing", "But at least make sure", "You cut my head off", "properly"};
        var expected = new List<string>{"There", "is", "nothing", "proper", "about", "what", "you", "are", "doing", "But", "at", "least", "make", "sure", "You", "cut", "my", "head", "off", "properly"};
    
        // When

        var result = RegExpr.SplitLine(input);
    
        // Then

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Given_single_String_Return_1_Long_String()
    {
        // Given
        var input = new List<string>{"You have exactly 2 hours to solve my ass slap puzzle"};
        var expected = new List<string>{"You", "have", "exactly", "2", "hours", "to", "solve", "my", "ass", "slap", "puzzle"};
    
        // When

        var result = RegExpr.SplitLine(input);
    
        // Then

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Given_many_Single_Word_Strings_Return_1_Long_String()
    {
        // Given
        var input = new List<string>{"3", "stanky", "legs"};
        var expected = new List<string>{"3", "stanky", "legs"};
    
        // When

        var result = RegExpr.SplitLine(input);
    
        // Then

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldReturnListOf8intints()
    {
        // Given
        var input = new List<string>{"1920x1080", "1024x768, 800x600, 640x480", "320x200, 320x240, 800x600", "1280x960"};
        var expected = new List<(int, int)>{(1920, 1080), (1024,768), (800,600), (640,480), (320,200), (320,240), (800,600),(1280,960)};
    
        // When

        var result = RegExpr.Resolution(input);
    
        // Then

       // expected.Should().BeEquivalentTo(result);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldReturnArrayOf8intints()
    {
        // Given
        var input = new string[]{"1920x1080", "1024x768, 800x600, 640x480", "320x200, 320x240, 800x600", "1280x960"};
        var expected = new List<(int, int)>{(1920, 1080), (1024,768), (800,600), (640,480), (320,200), (320,240), (800,600),(1280,960)};
    
        // When

        var result = RegExpr.Resolution(input);
    
        // Then

        //expected.Should().BeEquivalentTo(result);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void getInnerHtmlFromATag()
    {
        // Arrange
        var html = "<div>\n<p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>";
        var tag = "a";

        // Act
        var listOfInnerHtml = RegExpr.InnerText(html, tag);

        // Assert
        Assert.Equal(new List<String> {"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"}, listOfInnerHtml);
    }

    [Fact]
    public void getInnerHtmlFromPTagWithNesting()
    {
        // Arrange
        var html = "<div><a>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</a></div>";
        var tag = "p";

        // Act
        var listOfInnerHtml = RegExpr.InnerText(html, tag);

        // Assert
        Assert.Equal(new List<String> {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."}, listOfInnerHtml);
    }

    [Fact]
    public void getURLandTitle()
    {
        // Arrange
        var html = "<div>\n<p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>";

        // Act
        var listOfURLandTitles = RegExpr.Urls(html);
        var expectedResults = new List <(Uri, String)> {
            (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"), 
            (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
            (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
            (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
            (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
            (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)"),

        };

        // Assert
        Assert.Equal(expectedResults, listOfURLandTitles);
    }
}