using System.Linq;
using System.IO;

namespace FMBQ.Hub
{
    public static class Resources
    {
        public static Stream GetStream(string name)
        {
            var assembly = typeof(Resources).Assembly;
            string fullName = assembly.GetManifestResourceNames().First(fullName => fullName.EndsWith(name));

            return assembly.GetManifestResourceStream(fullName);
        }

        public static string GetString(string name)
        {
            using (Stream stream = GetStream(name))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
