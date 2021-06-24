using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface QueuePriorotyTDA
{
    /* Inicializa la esctructura */
    void InitiaiizeQueue();

    /* Ingresa un elemento a la estructura, ordenandolo por prioridad */
    void Enqueue(Player player);

    /* Elimina el "primer" valor de la estructura (el próximo a salir, el de mayor prioridad) */
    void Dequeue();

    /* Indica si hay elementos en la estructura */
    bool QueueEmpty();

    /* Devuelva el "primer" valor de la estructura (el próximo a salir, el de mayor prioridad) */
    Player First();

    /* Devuelve la prioridad del "primer" valor de la estructura (el próximo a salir, el de mayor prioridad) */
    int Priority();
}
