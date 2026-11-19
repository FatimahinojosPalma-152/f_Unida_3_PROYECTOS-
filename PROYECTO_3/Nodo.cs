using System;
using System.Collections.Generic;
using System.Text;

namespace PROYECTO_3
{
    public class Nodo
    {
        public char Dato;
        public Nodo Siguiente;

        public Nodo(char dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
