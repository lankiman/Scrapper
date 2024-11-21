using System.Reflection;

namespace Scrapper.Utils
{
    internal static class Helpers
    {
        public static string GetEmbeddedResourceContent(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {

                if (stream == null)
                {
                    throw new FileNotFoundException($"Embedded resource {resourceName} not found");
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
