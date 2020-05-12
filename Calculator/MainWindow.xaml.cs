using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void AddNumericalElement(Element element)
        {
            if (NumberBuilder.BuildNumber() == CalculatorModel.MostRecentResult)
                NumberBuilder.NewNumber();
            NumberBuilder.Append(ElementEvaluator.EvaluateElement(element));
            ShowNumber(NumberBuilder.BuildNumber());
        }

        private void AddOperatorElement(Element element)
        {
            float builtNumber = NumberBuilder.BuildNumber();
            CalculatorModel.AddNumberToCalculation(builtNumber);
            CalculatorModel.AddOperatorToCalculation(ElementEvaluator.EvaluateElement(element));
            ShowNumber(builtNumber);
            NumberBuilder.NewNumber();
        }

        private void DoOperation()
        {
            float mostRecentNumber = CalculatorModel.MostRecentNumber;
            float builtNumber = NumberBuilder.BuildNumber();
            CalculatorModel.AddNumberToCalculation(builtNumber);
            if (CalculatorModel.AmountOfNumbers == 1 && CalculatorModel.AmountOfOperators == 0)
            {
                CalculatorModel.AddOperatorToCalculation(CalculatorModel.MostRecentOperator);
                CalculatorModel.AddNumberToCalculation(mostRecentNumber);
            }
            NumberBuilder.NewNumber();
            ShowResult();
        }

        private void ZeroButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.ZERO);
        }

        private void OneButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.ONE);
        }

        private void TwoButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.TWO);
        }

        private void ThreeButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.THREE);
        }

        private void FourButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.FOUR);
        }
        
        private void FiveButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.FIVE);
        }

        private void SixButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.SIX);
        }

        private void SevenButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.SEVEN);
        }

        private void EightButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.EIGHT);
        }

        private void NineButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.NINE);
        }

        private void DecimalButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.DECIMAL);
        }

        private void SignChangeButtonClick(object sender, RoutedEventArgs e)
        {
            AddNumericalElement(Element.SIGN_CHANGE);
        }

        private void EqualButtonClick(object sender, RoutedEventArgs e)
        {
            DoOperation();
        }

        private void DivisionButtonClick(object sender, RoutedEventArgs e)
        {
            AddOperatorElement(Element.DIVISION);
        }

        private void MultiplicationButtonClick(object sender, RoutedEventArgs e)
        {
            AddOperatorElement(Element.MULTIPLICATION);
        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            AddOperatorElement(Element.MINUS);
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            AddOperatorElement(Element.PLUS);
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            NumberBuilder.NewNumber();
            ShowNumber(CalculatorModel.DEFAULT_START_VALUE);
        }

        private void ClearAllButtonClick(object sender, RoutedEventArgs e)
        {
            NumberBuilder.NewNumber();
            CalculatorModel.Clear();
            ShowNumber(CalculatorModel.DEFAULT_START_VALUE);
        }

        public void ShowResult()
        {
            var resultValue = CalculatorModel.GetResult();
            ShowNumber(resultValue);
            CalculatorModel.Clear();
            NumberBuilder.NewNumber();
            NumberBuilder.Append(resultValue.ToString());
        }

        public void ShowNumber(float number)
        {
            Result.Content = number;
        }

        private void AssignButtonClicks()
        {
            ZeroButton.Click += ZeroButtonClick;
            OneButton.Click += OneButtonClick;
            TwoButton.Click += TwoButtonClick;
            ThreeButton.Click += ThreeButtonClick;
            FourButton.Click += FourButtonClick;
            FiveButton.Click += FiveButtonClick;
            SixButton.Click += SixButtonClick;
            SevenButton.Click += SevenButtonClick;
            EightButton.Click += EightButtonClick;
            NineButton.Click += NineButtonClick;
            SignChangeButton.Click += SignChangeButtonClick;
            DecimalButton.Click += DecimalButtonClick;

            PlusButton.Click += PlusButtonClick;
            MinusButton.Click += MinusButtonClick;
            MultiplicationButton.Click += MultiplicationButtonClick;
            DivisionButton.Click += DivisionButtonClick;
            EqualButton.Click += EqualButtonClick;
            ClearButton.Click += ClearButtonClick;
            ClearAllButton.Click += ClearAllButtonClick;
        }

        private void UnassignButtonClicks()
        {
            ZeroButton.Click -= ZeroButtonClick;
            OneButton.Click -= OneButtonClick;
            TwoButton.Click -= TwoButtonClick;
            ThreeButton.Click -= ThreeButtonClick;
            FourButton.Click -= FourButtonClick;
            FiveButton.Click -= FiveButtonClick;
            SixButton.Click -= SixButtonClick;
            SevenButton.Click -= SevenButtonClick;
            EightButton.Click -= EightButtonClick;
            NineButton.Click -= NineButtonClick;
            SignChangeButton.Click -= SignChangeButtonClick;
            DecimalButton.Click -= DecimalButtonClick;

            PlusButton.Click -= PlusButtonClick;
            MinusButton.Click -= MinusButtonClick;
            MultiplicationButton.Click -= MultiplicationButtonClick;
            DivisionButton.Click -= DivisionButtonClick;
            EqualButton.Click -= EqualButtonClick;
            ClearButton.Click -= ClearButtonClick;
            ClearAllButton.Click -= ClearAllButtonClick;
        }

        public MainWindow()
        {
            InitializeComponent();
            AssignButtonClicks();
        }

        ~MainWindow()
        {
            UnassignButtonClicks();
        }
        

        
    }
}
