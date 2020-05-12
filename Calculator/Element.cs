using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum Element
    {
        NONE,
        ZERO,
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        SIGN_CHANGE,
        DECIMAL,
        PLUS,
        MINUS,
        MULTIPLICATION,
        DIVISION
    }

    public class ElementEvaluator
    {
        private const string ZERO_VALUE = "0";
        private const string ONE_VALUE = "1";
        private const string TWO_VALUE = "2";
        private const string THREE_VALUE = "3";
        private const string FOUR_VALUE = "4";
        private const string FIVE_VALUE = "5";
        private const string SIX_VALUE = "6";
        private const string SEVEN_VALUE = "7";
        private const string EIGHT_VALUE = "8";
        private const string NINE_VALUE = "9";
        private const string DECIMAL_VALUE = ",";
        private const string SIGN_CHANGE_VALUE = "+/-";
        private const string PLUS_VALUE = "+";
        private const string MINUS_VALUE = "-";
        private const string MULTIPLICATION_VALUE = "*";
        private const string DIVISION_VALUE = "/";
        private const string DEFAULT_VALUE = "";

        public static String EvaluateElement(Element element)
        {
            switch(element)
            {
                case Element.ZERO:
                    return ZERO_VALUE;
                case Element.ONE:
                    return ONE_VALUE;
                case Element.TWO:
                    return TWO_VALUE;
                case Element.THREE:
                    return THREE_VALUE;
                case Element.FOUR:
                    return FOUR_VALUE;
                case Element.FIVE:
                    return FIVE_VALUE;
                case Element.SIX:
                    return SIX_VALUE;
                case Element.SEVEN:
                    return SEVEN_VALUE;
                case Element.EIGHT:
                    return EIGHT_VALUE;
                case Element.NINE:
                    return NINE_VALUE;
                case Element.DECIMAL:
                    return DECIMAL_VALUE;
                case Element.SIGN_CHANGE:
                    return SIGN_CHANGE_VALUE;
                case Element.PLUS:
                    return PLUS_VALUE;
                case Element.MINUS:
                    return MINUS_VALUE;
                case Element.MULTIPLICATION:
                    return MULTIPLICATION_VALUE;
                case Element.DIVISION:
                    return DIVISION_VALUE;
                case Element.NONE:
                    return DEFAULT_VALUE;
                default:
                    return DEFAULT_VALUE;
            }
        }

        public static Element EvaluateValue(String value)
        {
            switch (value)
            {
                case ZERO_VALUE:
                    return Element.ZERO;
                case ONE_VALUE:
                    return Element.ONE;
                case TWO_VALUE:
                    return Element.TWO;
                case THREE_VALUE:
                    return Element.THREE;
                case FOUR_VALUE:
                    return Element.FOUR;
                case FIVE_VALUE:
                    return Element.FIVE;
                case SIX_VALUE:
                    return Element.SIX;
                case SEVEN_VALUE:
                    return Element.SEVEN;
                case EIGHT_VALUE:
                    return Element.EIGHT;
                case NINE_VALUE:
                    return Element.NINE;
                case DECIMAL_VALUE:
                    return Element.DECIMAL;
                case SIGN_CHANGE_VALUE:
                    return Element.SIGN_CHANGE;
                case PLUS_VALUE:
                    return Element.PLUS;
                case MINUS_VALUE:
                    return Element.MINUS;
                case MULTIPLICATION_VALUE:
                    return Element.MULTIPLICATION;
                case DIVISION_VALUE:
                    return Element.DIVISION;
                default:
                    return Element.NONE;
            }
        }


        public static bool IsNumber(Element element)
        {
            return IsNumber(EvaluateElement(element));
        }

        public static bool IsNumber(string value)
        {
            return int.TryParse(value, out int result); 
        }

        public static bool IsOperator(Element element)
        {
            return IsOperator(EvaluateElement(element));
        }

        public static bool IsOperator(string value)
        {
            return !IsNumber(value) && value != DECIMAL_VALUE && value != SIGN_CHANGE_VALUE;
        }
    }

}
