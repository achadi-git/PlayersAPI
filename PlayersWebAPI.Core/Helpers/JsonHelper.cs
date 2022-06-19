using Newtonsoft.Json;
using System.IO;

namespace PlayersWebAPI.Core.Helpers
{
    public static class JsonHelper
    {
        public static T DeserializeJson<T>(this Stream stream, JsonSerializerSettings settings = null)
        {
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = JsonSerializer.CreateDefault(settings);
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
