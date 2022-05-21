using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.
 */
namespace Cracking.Misc
{
    class LC535
    {
        public class Codec {

            Random rand = new Random();

            static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            static string urlPrefix = "https://tinyurl.com/";

            public Dictionary<string, string> urlToHash = new Dictionary<string, string>();

            public Dictionary<string, string> hashToUrl = new Dictionary<string, string>();

            // Encodes a URL to a shortened URL
            public string encode(string longUrl) 
            {
                if (urlToHash.ContainsKey(longUrl))
                {
                    return urlToHash[longUrl];
                }

                string hashUrl = urlPrefix + createNewHash();
                
                while (hashToUrl.ContainsKey(hashUrl))
                {
                    hashUrl = createNewHash();
                }

                urlToHash[longUrl] = hashUrl;
                hashToUrl[hashUrl] = longUrl;

                return hashUrl;
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl) 
            {
                return hashToUrl[shortUrl];
            }

            public string createNewHash()
            {
                char[] hash = new char[6];

                for (int i = 0; i < hash.Length; i++)
                {
                    hash[i] = chars[rand.Next(chars.Length)];
                }

                return new string(hash);
            }
        }
    }

    [TestClass]
    public class Tests_LC535
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
