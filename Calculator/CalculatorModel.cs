using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorModel
    {
        private static List<float> Numbers = new List<float>();
        private static List<string> Operators = new List<string>();
        public const float DEFAULT_START_VALUE = 0f;
        public static float MostRecentNumber = DEFAULT_START_VALUE;
        public static string MostRecentOperator = "";
        public static float MostRecentResult = DEFAULT_START_VALUE;
        public static int AmountOfNumbers => Numbers.Count;
        public static int AmountOfOperators => Operators.Count;

        private static float CalculateResult()
        {
            return Calculate(Numbers, Operators);
        }

        private static float Calculate(List<float> numbers, List<string> operators)
        {
            List<float> tempNumbers = new List<float>(numbers);
            float currentValue = tempNumbers[0];
            string currentOperator = "";
            tempNumbers.RemoveAt(0);
            for(int i = 0; i < operators.Count && tempNumbers.Count > 0; i++)
            {
                currentOperator = operators[i];
                switch(ElementEvaluator.EvaluateValue(operators[i]))
                {
                    case Element.PLUS:
                        currentValue += tempNumbers.First();
                        break;
                    case Element.MINUS:
                        currentValue -= tempNumbers.First();
                        break;
                    case Element.MULTIPLICATION:
                        currentValue *= tempNumbers.First();
                        break;
                    case Element.DIVISION:
                        currentValue /= tempNumbers.First();
                        break;
                    default:
                        currentValue = DEFAULT_START_VALUE;
                        break;
                }
                tempNumbers.Remove(tempNumbers.First());
            }
            return currentValue;
        }

        public static void AddOperatorToCalculation(string tempOperator)
        {
            Operators.Add(tempOperator);
            MostRecentOperator = tempOperator;
        }

        public static void AddNumberToCalculation(float number)
        {
            Numbers.Add(number);
            MostRecentNumber = number;
        }

        public static float GetResult()
        {
            var result = 0f;
            if (Numbers.Count > Operators.Count && Numbers.Count > 1 && Operators.Count > 0)
                result = CalculateResult();
            else
                result = DEFAULT_START_VALUE;
            MostRecentResult = result;
            return result;
        }

        public static void Clear()
        {
            Numbers.Clear();
            Operators.Clear();
        }
    }
}
