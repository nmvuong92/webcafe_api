using System;
using System.Linq;
namespace VD.Lib
{
    public  class myStringArr
    {
        public static int[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new int[0];
            }

            //cái: piece
            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;


            return split.ToArray().Select(int.Parse).ToArray();
        }

        public static string[] SplitStringNative(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new string[0];
            }

            //cái: piece
            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }
        public static decimal[] SplitStringDecimal(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new decimal[0];
            }
            //cái: piece
            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray().Select(decimal.Parse).ToArray();
        }
    }

   
     
    
}
