using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaEstatica
{
    private int count;
    private int size;
    private GameObject[] Cola;

    public ColaEstatica(int size)
    {
        this.size = size;
        this.count = 0;
        Cola = new GameObject[size];
    }

    public void Enqueue(GameObject obj)
    {
        if (this.size >= count + 1)
        {
            Cola[count++] = obj;
        }
    }
    public GameObject Dequeue()
    {
        GameObject dequeue = Cola[0];
        if (count>0)
        {
            for (int i = 0; i < count; i++)
            {
                Cola[i] = Cola[i + 1];
            }
            count--;
        }


        return dequeue;
    }

}
