using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iLinkedList
{
    void Add(Node node);
    Node GetFirst();
    Node GetLast();
    int IndexOf(Rigidbody part);
    void RemoveAt(int index);
    void Remove(Rigidbody part);
    void Insert(int index, Node node);
}
