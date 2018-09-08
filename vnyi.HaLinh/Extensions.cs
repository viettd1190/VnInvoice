using Newtonsoft.Json;

namespace vnyi.HaLinh
{
    public static class Extensions
    {
        public static string ToJson(this object input)
        {
            return JsonConvert.SerializeObject(input,
                                               Formatting.None);
        }

        public static T ToObject<T>(this string input)
                where T : class
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
