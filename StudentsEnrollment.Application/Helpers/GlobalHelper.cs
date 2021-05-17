using System.IO;

namespace StudentsEnrollment.Application.Helpers
{
    public static class GlobalHelper
    {
        public const string AnyJokeUrl = "v2/joke/Any";

        public static string GetRequestBody(Stream stream)
        {
            var bodyStream = new StreamReader(stream);
            bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
            var bodyText = bodyStream.ReadToEnd();
            return bodyText;
        }
    }
}
