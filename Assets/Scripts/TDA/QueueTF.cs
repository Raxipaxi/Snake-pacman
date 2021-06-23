using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTF : QueuePriorotyTDA
{
    private int index;
    public Player[] Ranking;

    public void InitiaiizeQueue()
    {
        Ranking = new Player[100];
        index = 0;
    }

    public void Enqueue(Player player)
    {
        if(QueueEmpty())
        {
            Ranking[0] = player;
            index++;
        }
        else if (index < Ranking.Length)
        {
            Ranking[index] = player;
            index++;
        }
    }

    public void Dequeue()
    {
        Ranking[index-1] = null;
        index--;
    }

    public Player DequeueWithReturn()
    {
        var player = Ranking[index - 1];
        Ranking[index - 1] = null;
        index--;
        return player;
    }



    public Player First() => Ranking[index-1];  

    public int Priority() => Ranking[index-1].Score;

    public bool QueueEmpty() => (index == 0);

    public Player[] GetRanking()
    {
        quickSort(Ranking, 0, index > 0 ? index -1 : 0);

        return Ranking;
    }

    public int Partition(Player[] arr, int left, int right)
    {
        int pivot;
        int aux = (left + right) / 2;   //tomo el valor central del vector
        pivot = arr[aux].Score;

        Debug.Log(string.Format("left: {0}, right: {1}", left, right));
        // en este ciclo debo dejar todos los valores menores al pivot
        // a la izquierda y los mayores a la derecha
        while (true)
        {
            // se pregunta primero por mayor 
            while (arr[left].Score > pivot)
            {
                Debug.Log("Left");
                left++;
            }
            while (arr[right].Score < pivot)
            {
                Debug.Log("Right");
                right--;
            }
            while(arr[right].Score == pivot)
            {
                Debug.Log("PROBLEMA CRASH UNITY RESUELTO =D");
                return right;
            }
            if (left < right)
            {
                Player temp = arr[right];
                arr[right] = arr[left];
                arr[left] = temp;
            }
            else
            {
                // este es el valor que devuelvo como proxima posicion de
                // la particion en el siguiente paso del algoritmo
                return right;
            }
        }
    }

    public void quickSort(Player[] arr, int left, int right)
    {
        int pivot;
        if (left < right)
        {
            pivot = Partition(arr, left, right);
            if (pivot > 1)
            {
                // mitad del lado izquierdo del vector
                quickSort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                // mitad del lado derecho del vector
                quickSort(arr, pivot + 1, right);
            }
        }
    }
}