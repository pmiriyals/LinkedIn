using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostfixExp
{
    class Program
    {
        public static double postfix(string s)
        {
            string s1 = "";
            double op2, x;
            Stack<double> stk = new Stack<double>();

            foreach (char c in s)
            {
                if (char.IsNumber(c) || c == '.')
                {
                    s1 += c;
                }
                else if (c == ' ')
                {
                    if(double.TryParse(s1, out x))
                        stk.Push(x);
                    s1 = "";
                }
                else
                {
                    if (s1.Length > 0)
                    {
                        if (double.TryParse(s1, out x))
                            stk.Push(x);
                        s1 = "";
                    }

                    switch (c)
                    {
                        case '+': 
                                    if (stk.Count > 1)
                                        stk.Push(stk.Pop() + stk.Pop());
                                    else
                                        Console.WriteLine("Error: insufficient operands");
                                    break;

                        case '*':
                                    if (stk.Count > 1)
                                        stk.Push(stk.Pop() * stk.Pop());
                                    else
                                        Console.WriteLine("Error: insufficient operands");
                                    break;

                        case '-':
                                    if (stk.Count > 1)
                                    {
                                        op2 = stk.Pop();
                                        stk.Push(stk.Pop() - op2);
                                    }
                                    else
                                        Console.WriteLine("Error: insufficient operands");
                                    break;

                        case '/':
                                    if (stk.Count > 1)
                                    {
                                        op2 = stk.Pop();
                                        if (op2 != 0)
                                            stk.Push(stk.Pop() / op2);
                                        else
                                        {
                                            Console.WriteLine("Division by zero exception");
                                            return -1;
                                        }
                                    }
                                    else
                                        Console.WriteLine("Error: insufficient operands");
                                    break;

                        case '%':
                                    if (stk.Count > 1)
                                    {
                                        op2 = stk.Pop();
                                        if (op2 != 0)
                                            stk.Push(stk.Pop() / op2);
                                        else
                                        {
                                            Console.WriteLine("Modulous by zero exception");
                                            return -1;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error: insufficient operands");
                                    }
                                    break;

                        default: Console.WriteLine("\nError unidentified char");
                                return -1;
                    }
                }
            }
            if(stk.Count > 0)
                return stk.Pop();
            else
            {
                return -1;
            }
        }

        public static double PostFixEval(string s)
        {
            string[] tokens = s.Split(' ');
            double num, op2;
            Stack<double> operands = new Stack<double>();

            foreach (string t in tokens)
            {
                if (double.TryParse(t, out num))
                {
                    operands.Push(num);
                }
                else
                {
                    switch (t)
                    {
                        case "+":
                            if (operands.Count > 1)
                                operands.Push(operands.Pop() + operands.Pop());
                            else
                                Console.WriteLine("Error: insufficient operands");
                            break;

                        case "*":
                            if (operands.Count > 1)
                                operands.Push(operands.Pop() * operands.Pop());
                            else
                                Console.WriteLine("Error: insufficient operands");
                            break;

                        case "-":
                            if (operands.Count > 1)
                            {
                                op2 = operands.Pop();
                                operands.Push(operands.Pop() - op2);
                            }
                            else
                                Console.WriteLine("Error: insufficient operands");
                            break;

                        case "/":
                            if (operands.Count > 1)
                            {
                                op2 = operands.Pop();
                                if (op2 != 0)
                                    operands.Push(operands.Pop() / op2);
                                else
                                {
                                    Console.WriteLine("Division by zero exception");
                                    return -1;
                                }
                            }
                            else
                                Console.WriteLine("Error: insufficient operands");
                            break;

                        case "%":
                            if (operands.Count > 1)
                            {
                                op2 = operands.Pop();
                                if (op2 != 0)
                                    operands.Push(operands.Pop() / op2);
                                else
                                {
                                    Console.WriteLine("Modulous by zero exception");
                                    return -1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: insufficient operands");
                            }
                            break;

                        default: Console.WriteLine("\nError unidentified char");
                            return -1;
                    }
                }

            }
            if (operands.Count > 0)
                return operands.Pop();
            else
                return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PostFixEval("5.5 1 2 + 4 * + 3 -"));
            Console.ReadLine();
        }
    }
}
