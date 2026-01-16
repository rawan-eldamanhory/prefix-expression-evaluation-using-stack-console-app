using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class PrefixEvaluator
    {
        private static float ApplyOperation(float operand1, float operand2, char operation)
        {
            switch (operation)
            {
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '/':
                    if (operand2 == 0)
                        throw new DivideByZeroException("Division by zero is not allowed.");
                    return operand1 / operand2;
                default:
                    throw new InvalidOperationException("Invalid operator.");
            }
        }

        public static float EvaluatePrefix(string expression)
        {
            Stack<float> stack = new Stack<float>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char ch = expression[i];

                if (char.IsDigit(ch))
                {
                    stack.Push(ch - '0'); 
                }
                else
                {
                    if (stack.Count < 2)
                        throw new InvalidOperationException("Invalid prefix expression.");

                    float operand1 = stack.Pop();
                    float operand2 = stack.Pop();

                    float result = ApplyOperation(operand1, operand2, ch);
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string prefixExpression = "+3-72";
            Console.WriteLine("The result = " + PrefixEvaluator.EvaluatePrefix(prefixExpression));    // 8

            Console.ReadKey();
        }
    }
}
