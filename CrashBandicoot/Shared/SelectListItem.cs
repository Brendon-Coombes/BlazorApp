
namespace CrashBandicoot.Shared
{
    public class SelectListItem
    {
        public SelectListItem(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
