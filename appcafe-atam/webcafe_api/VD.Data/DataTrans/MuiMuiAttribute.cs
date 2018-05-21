using System.ComponentModel;
namespace VD.Data.DataTrans
{
    public class MuiMuiAttribute : DisplayNameAttribute
    {
        public MuiMuiAttribute(string resourceId)
            : base(GetMessageFromResource(resourceId))
        { }

        private static string GetMessageFromResource(string resourceId)
        {
            // TODO: Return the string from the resource file
            return mui.ResourceManager.GetString(resourceId);
        }
    }
}