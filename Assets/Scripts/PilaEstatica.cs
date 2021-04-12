using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaEstatica
{
    private int count;
    private int size;
    private Object[] Pila;

    public PilaEstatica(int size)
    {
        this.size = size;
        Pila = new Object[size];
        this.count = 0;
    }

    void Push(Object obj)
    {
        if (this.size >= count + 1)
        {
            Pila[count++] = obj;
        }
        
    }
    Object Pop()
    {
        if (count - 1 > 0)
        {
            return Pila[count--];
        }
        else
        {
            return Pila[0];
        }
        
    }
    int Count()
    {
        return count;
    }
}
