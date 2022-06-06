using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Translation
{
    public class CheckInput
    {
        public bool CheckInputValue(string value1, string value2)
        {
                int numericLanguageCode, numbericKeyWord;
                bool isLanguageCodeString = int.TryParse(value1, out numericLanguageCode);
                bool isKeyWordString = int.TryParse(value2, out numbericKeyWord);

                if (isLanguageCodeString && isKeyWordString)
                    return false;
                return true;
        }
    }
}
