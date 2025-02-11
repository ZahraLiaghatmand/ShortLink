using ShortLink.Application.Common.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

class ShortCodeGenerator : IShortCodeGenerator
{
    public string Generator(string url)
    {
        // Ensure URL starts with "http://" or "https://"
        if (!url.StartsWith("http://") && !url.StartsWith("https://"))
        {
            url = "http://" + url;
        }

        // Extract the main domain (ignore subdomains like "blog.")
        var domainMatch = Regex.Match(url, @"https?:\/\/(?:www\.)?(?:([\w-]+)\.)?([\w-]+)\.\w+");
        string domainPart = domainMatch.Success ? domainMatch.Groups[2].Value : "xxx";

        // Remove vowels from domain
        domainPart = RemoveVowels(domainPart);

        // Ensure at least 3 domain characters, pad if needed
        string shortDomain = domainPart.Length >= 3 ? domainPart.Substring(0, 3) : domainPart.PadRight(3, 'x');

        // Extract the path after TLD, removing query params and file extensions
        var pathMatch = Regex.Match(url, @"https?:\/\/[^\/]+\/([^?#]+)");
        string pathPart = pathMatch.Success ? pathMatch.Groups[1].Value : "";

        // Remove vowels, special characters, and common file extensions
        pathPart = RemoveVowels(pathPart).Replace("-", "").Replace("_", "").Replace(".", "");
        pathPart = Regex.Replace(pathPart, @"\.(html|php|asp|aspx|jsp|txt)$", ""); // Remove file extensions

        // Take 3 characters from path or generate fallback if too short
        string shortPath = pathPart.Length >= 3 ? pathPart.Substring(0, 3) : GenerateFallback(url, 3 - pathPart.Length);

        // Add a unique 2-character suffix from hash
        string uniqueSuffix = GenerateFallback(url, 2);

        return shortDomain + shortPath + uniqueSuffix;
    }

    private static string RemoveVowels(string input)
    {
        return new string(input.Where(c => !"aeiouAEIOU".Contains(c)).ToArray());
    }

    private static string GenerateFallback(string input, int length)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            string hashString = Convert.ToBase64String(hash)
                                .Replace("+", "")
                                .Replace("/", "")
                                .Replace("=", ""); // Remove special characters
            return hashString.Substring(0, length);
        }
    }
}
