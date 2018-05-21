using System.ComponentModel;

namespace Web
{
    public class MuiMuiAttribute : DisplayNameAttribute
    {
        public MuiMuiAttribute(string resourceId)
            : base(GetMessageFromResource(resourceId))
        { }

        private static string GetMessageFromResource(string resourceId)
        {
            // TODO: Return the string from the resource file
            return mui.mui.ResourceManager.GetString(resourceId);
        }
    }
}