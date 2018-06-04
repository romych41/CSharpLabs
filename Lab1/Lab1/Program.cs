using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void InputMatrix(ref int n, ref double[,] matrix)
        {
            Console.WriteLine("Введите кол-во абонентов(не менее 2-ух и не более "+Int32.MaxValue+"): ");
            n = Convert.ToInt32(Console.ReadLine());
            matrix = new double[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (i != j)
                    {
                        Console.WriteLine("\nВведите стоимость соединения {0}-го и {1}-го абонентов", i + 1, j + 1);
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                        matrix[i, j] = Int32.MaxValue;
                }
                for(int j=0;j<i;j++)
                {
                    matrix[i, j] = matrix[j, i];
                }
            }
        }


        static void SearchRoute(ref int n, ref double[,] matrix)
        {
            int[,] route = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    route[i, j] = i;

            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] > matrix[i, k] + matrix[k, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                            route[i, j]=route[k,j];
                        }
                    }
            
            double min = Int32.MaxValue;
            ArrayList points = new ArrayList(n);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if ((min > matrix[i, j])&&(i!=j))
                    {
                        points.Clear();
                        min = matrix[i, j];
                        points.Add(i);
                        IntermediateRoute(i, j, ref route, ref points);
                        points.Add(j);
                    }
            OutputRoute(ref n, ref matrix, ref route, ref points);
            Console.WriteLine();
            Console.Write("Общая стоимость данного маршрута: " + TotalCost(ref n, ref matrix, ref points));
        }


        static void OutputRoute(ref int n, ref double[,] matrix, ref int[,] route, ref ArrayList points)
        {
            Console.WriteLine("Маршрут абонентов: ");
            Route temp = new Route(0, 0);
            for (int k = 1, i = (int)points[points.Count - 1]; k < n - 1; k++)
            {
                double min = Int32.MaxValue;
                for (int j = 0; j < n; j++)
                    if ((min > matrix[i, j]) && (i != j) && (!points.Contains(j)))
                    {
                        min = matrix[i, j];
                        temp = new Route(i, j);
                    }
                i = temp.secondPoint;
                points.Add(temp.secondPoint);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Object tmp in points)
            {
                Console.Write(((int)tmp + 1) + " ");
            }
            Console.ResetColor();
        }


        static void IntermediateRoute(int a, int b, ref int[,] route, ref ArrayList list)
        {
            int k = route[a, b];
            if ((k == 0) || (k == a) || (k == b))
                return;
            IntermediateRoute(a, k, ref route, ref list);
            list.Add(k);
            IntermediateRoute(k, b, ref route, ref list);
        }


        static double TotalCost(ref int n, ref double[,] matrix, ref ArrayList points)
        {
            double allCost = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            for(int i=1;i<points.Count;i++)
            {
                allCost += matrix[(int)points[i - 1], (int)points[i]];
            }
            Console.ResetColor();
            return allCost;
        }


        static void OutputMatrix(ref int n, ref double[,] matrix)
        {
            Console.Write("   ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,3} ", i + 1);
            }
            Console.WriteLine();
            Console.ResetColor();
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0,3}", i + 1);
                Console.ResetColor();
                Console.Write("|", i + 1);
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        Console.Write("{0,3}|", matrix[i, j]);
                    else
                        Console.Write("   |");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            double[,] pMatrix = { };
            int n = 0;
            InputMatrix(ref n, ref pMatrix);
            OutputMatrix(ref n, ref pMatrix);
            SearchRoute(ref n, ref pMatrix);
            Console.ReadKey();
        }
    }
}
