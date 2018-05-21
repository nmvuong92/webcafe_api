using System;
using System.Text.RegularExpressions;
namespace VD.Lib
{
    public class myRegex
    {
        public static string BoTagScriptAndCSS(string input){
            try
            {
                var regex = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase
                    );
                return regex.Replace(input, "");
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
