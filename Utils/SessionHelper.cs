using System.Text.Json;

namespace Coffee_store.Utils
{
    public static class SessionHelper
    {
        public static void SetItemToSession<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }
        public static T? GetItemFromSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value is null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
