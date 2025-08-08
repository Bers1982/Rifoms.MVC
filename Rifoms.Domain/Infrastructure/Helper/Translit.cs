using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifoms.Domain.Infrastructure.Helper
{
    /// <summary>
    /// Подробнее: https://www.securitylab.ru/blog/personal/reply-to-all/155943.php
    /// 
    /// Делает транслит кириллицы до 39 символов, нужен для закрепления
    /// SEOLINK'a
    /// </summary>
    public static class Translit
    {
        public static string RusToEng(string s)
        {
            StringBuilder returnString = new StringBuilder();
            s = s.ToLowerInvariant();
            string[] rus = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й",
          "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц",
          "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"," " };

            string[] eng = { "a", "b", "v", "g", "d", "e", "e", "zh", "z", "i", "y",
          "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts",
          "ch", "sh", "shch", null, "y", null, "e", "yu", "ya","-" };


            for (int j = 0; j < s.Length; j++)
            {
                for (int i = 0; i < rus.Length; i++)
                {
                    if (s.Substring(j, 1) == rus[i])
                    {
                        if (!String.IsNullOrEmpty(eng[i]))
                        {
                            if (returnString.Length < 39)
                            {
                                returnString.Append(eng[i].ToLowerInvariant());
                            }
                        }
                    }
                }
            }

            var result = returnString.ToString();
            if(result.EndsWith("-"))
            {
                result = result.Remove(result.Length-1, 1);
            } 

            return result;
        }
    }
}
