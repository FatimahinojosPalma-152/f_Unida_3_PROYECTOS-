using PROYECTO_3;
using System;

namespace PROYECTO_4
{
    class Program
    {
        static bool EsOperador(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^';
        }

        static int Precedencia(char operador)
        {
            switch (operador)
            {
                case '+':
                case '-': return 1;
                case '*':
                case '/':
                case '%': return 2;
                case '^': return 3;
                default: return 0;
            }
        }

        public static string InfijaAPostfija(string infija)
        {
            Pila pila = new Pila();
            string salida = "";

            for (int i = 0; i < infija.Length; i++)
            {
                char c = infija[i];

                if (char.IsWhiteSpace(c)) continue;

                if (char.IsLetterOrDigit(c) || c == '.')
                {
                    salida += c;
                }
                else if (c == '(')
                {
                    pila.Apilar(c);
                }
                else if (c == ')')
                {
                    while (!pila.Vacia() && pila.Cima() != '(')
                    {
                        salida += pila.Desapilar();
                    }
                    if (!pila.Vacia() && pila.Cima() == '(')
                    {
                        pila.Desapilar();
                    }
                }
                else if (EsOperador(c))
                {
                    while (!pila.Vacia() && pila.Cima() != '(' && Precedencia(pila.Cima()) >= Precedencia(c))
                    {
                        salida += pila.Desapilar();
                    }
                    pila.Apilar(c);
                }
            }

            while (!pila.Vacia())
            {
                salida += pila.Desapilar();
            }

            return salida;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==== CALCULADORA ====");
            Console.Write("Expresion: ");
            string expresion = Console.ReadLine();

            string postfija = InfijaAPostfija(expresion);

            Console.WriteLine($"Postfija: {postfija}");
            Console.ReadKey();
        }
    }
}