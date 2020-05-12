using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class NumberBuilder
    {
        private const float DEFAULT_FLOAT_VALUE = 0;
        private const string DEFAULT_STRING_VALUE = "";
        private static string NumberAsString = DEFAULT_STRING_VALUE;
        private static float Number => GetNumberFromString();

        public static void NewNumber()
        {
            NumberAsString = DEFAULT_STRING_VALUE;
        }

        private static float GetNumberFromString()
        {
            bool conversionPossible = float.TryParse(NumberAsString, out float result);
            if (conversionPossible) return result;
            return DEFAULT_FLOAT_VALUE;
        }

        public static void Append(string addedCharacters)
        {
            if (ElementEvaluator.IsOperator(addedCharacters)) return;
            if (ElementEvaluator.EvaluateValue(addedCharacters) == Element.DECIMAL && NumberAsString.Contains(ElementEvaluator.EvaluateElement(Element.DECIMAL)))
                return;

            float multiplication = 1;
            string tempAddedCharacters = addedCharacters;
            for(int i = 0; i < tempAddedCharacters.Length; i++)
            {
                if(tempAddedCharacters.Contains(ElementEvaluator.EvaluateElement(Element.SIGN_CHANGE)))
                {
                    multiplication *= -1;
                    int foundIndex = tempAddedCharacters.IndexOf(ElementEvaluator.EvaluateElement(Element.SIGN_CHANGE));
                    int foundLength = ElementEvaluator.EvaluateElement(Element.SIGN_CHANGE).Length;
                    tempAddedCharacters = tempAddedCharacters.Remove(foundIndex, foundLength);
                }
            }
            NumberAsString += tempAddedCharacters;
            string temp = NumberAsString;
            NumberAsString = (multiplication * Number).ToString();
            if (temp != NumberAsString)
            {
                if (NumberAsString.Contains("-"))
                {
                    string signChanged = temp.Insert(0, "-");
                    if (signChanged != NumberAsString)
                        NumberAsString += ",";
                }
                else if (temp.Contains("-"))
                {
                    string tempNumberAsString = NumberAsString.Insert(0, "-");
                    if (temp != tempNumberAsString)
                        NumberAsString += ",";
                }
                else
                {
                    NumberAsString += ",";
                }

            }
        }

        public static float BuildNumber()
        {
            return Number;
        }

    }
}
