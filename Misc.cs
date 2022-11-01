using System.Security.Cryptography;
using System.Text;

namespace webNET_Hits_backend_aspnet_project_1 {
    public class Misc {
        public static List<List<T>> Split<T>(IList<T> source, int groupSize) {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / groupSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static string ToHash(string pass) {
            var tmpSource = ASCIIEncoding.ASCII.GetBytes(pass);
            var hash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return System.Text.Encoding.UTF8.GetString(hash);
        }
    }
}
