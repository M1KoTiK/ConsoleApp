using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextGame.Converters
{
    public class CalcParser : IActionParser
    {
        public string Key => "Calc";

        public void ParseAndExecute(string parsableString)
        {
            if (parsableString == null || parsableString == "")
            {
                return;
            }
            Console.WriteLine(EvaluateExpression(parsableString));
        }

        static double EvaluateExpression(string expression)
        {
            var tokens = Tokenize(expression);
            var rpn = ConvertToRPN(tokens);
            return EvaluateRPN(rpn);
        }

        static List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            var currentNumber = "";

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (char.IsDigit(c) || c == '.')
                {
                    currentNumber += c; // собираем число
                }
                else if (c == ' ')
                {
                    if (currentNumber != "")
                    {
                        tokens.Add(currentNumber);
                        currentNumber = "";
                    }
                }
                else
                {
                    if (currentNumber != "")
                    {
                        tokens.Add(currentNumber);
                        currentNumber = "";
                    }
                    tokens.Add(c.ToString()); // добавляем оператор или скобку
                }
            }

            if (currentNumber != "")
            {
                tokens.Add(currentNumber);
            }

            return tokens;
        }

        static List<string> ConvertToRPN(List<string> tokens)
        {
            var output = new List<string>();
            var operators = new Stack<string>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    output.Add(token); // если это число, добавляем в выходную строку
                }
                else if (token == "(")
                {
                    operators.Push(token); // если это открывающая скобка, добавляем в стек
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Pop(); // удаляем открывающую скобку
                }
                else // оператор
                {
                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(token))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                output.Add(operators.Pop());
            }

            return output;
        }

        static int GetPrecedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }

        static double EvaluateRPN(List<string> rpn)
        {
            var stack = new Stack<double>();

            foreach (var token in rpn)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double result = token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => a / b,
                        _ => throw new InvalidOperationException("Неизвестный оператор")
                    };
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }
    }
}
