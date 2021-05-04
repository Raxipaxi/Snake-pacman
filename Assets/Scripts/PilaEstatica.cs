using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaEstatica
{
    private int count;
    private int size;
    private GameObject[] Pila;

    public PilaEstatica(int size)
    {
        this.size = size;
        Pila = new GameObject[size];
        this.count = 0;
    }

    void Push(GameObject obj)
    {
        if (this.size >= count + 1)           
            Pila[count++] = obj;
    }
    GameObject Pop()
    {
        if (!Empty())
        {
            return Pila[count--];
        }
        else
        {
            return Pila[0];
        }
        
    }
    bool Empty()
    {
        if (count==0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    int Count()
    {
        return count;
    }
}
