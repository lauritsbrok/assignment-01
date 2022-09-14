using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines){
        var wordPattern = @"([A-Za-z0-9])\w*";
        var spacePattern = @" ";
        foreach(string line in lines){
            string[] words = Regex.Split(line, spacePattern, RegexOptions.IgnoreCase);
            foreach(string word in words){
                var match   = Regex.Match(word, wordPattern);
                yield return (match.Value);
            }
            
            
            
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions){
        var pattern = @"^(?<width>\d{3,4})x(?<height>\d{3,4})$";
        var rg = new Regex(pattern);

        foreach(string s in resolutions){
            string[] words = s.Split(',');
            foreach (var word in words){
                var trimmed = word.Trim();
                var match   = Regex.Match(trimmed, pattern);
                var width   = int.Parse(match.Groups["width"].Value);
                var height  = int.Parse(match.Groups["height"].Value);
                yield return (width, height);
            }
        }
    }

    // Regex: (?<=">|a>)\w.*?(?=<\/a>) where "a" is a variable
    public static IEnumerable<string> InnerText(string html, string tag) {
        String pattern = "(?<=\">|a>)\\w.*?(?=<\\/a>)";
        String replacePattern = "<\\w+>|<\\/\\w+>";
        MatchCollection matches = Regex.Matches(html, pattern);
        foreach(Match match in matches){
            var replacedMatch = Regex.Replace(match.ToString(), replacePattern, "");
            yield return replacedMatch.ToString();
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html){
        String pattern = "(?<=href=\"|title=\").*?(?=\")";
        MatchCollection matches = Regex.Matches(html, pattern);
        for(int i = 0; i < matches.Count(); i = i+2){
            yield return (new Uri(matches[i].ToString()), matches[i+1].ToString());
        }
    }
}