using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class ConjuntoTA : iConjunto
    {
        int[] a;
        int cant;

        public void Agregar(int x)
        {
            if (!this.Pertenece(x))
            {
                a[cant] = x;
                cant++;
            }
        }
        public bool ConjuntoVacio()
        {
            return cant == 0;
        }

        public int Elegir()
        {
            return a[cant - 1];
        }

        public void InicializarConjunto()
        {
            a = new int[255];
            cant = 0;
        }

        public bool Pertenece(int x)
        {
            int i = 0;
            while (i < cant && a[i] != x)
            {
                i++;
            }
            return (i < cant);
        }

        public void Sacar(int x)
        {
            int i = 0;
            while (i < cant && a[i] != x)
            {
                i++;
            }
            if (i < cant)
            {
                a[i] = a[cant - 1];
                cant--;
            }
        }
    }
