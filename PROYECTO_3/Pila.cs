using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PROYECTO_3
{
    public class Pila
    {
        private Nodo tope;

        public Pila()
        {
            tope = null;
        }

        public bool Vacia()
        {
            return tope == null;
        }

        public void Apilar(char dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public char Desapilar()
        {
            if (Vacia()) return '\0';
            char dato = tope.Dato;
            tope = tope.Siguiente;
            return dato;
        }

        public char Cima()
        {
            if (Vacia()) return '\0';
            return tope.Dato;
        }
    }
}
