using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    Rigidbody part;
    Node next = null;

    public Node(Rigidbody part)
    {
        this.part = part;
    }

    public void SetNext(Node node)
    {
        next = node;
    }
    public Node GetNext()
    {
        return next;
    }
    public void SetPart(Rigidbody part)
    {
        this.part = part;
    }
    public Rigidbody GetPart()
    {
        return part;
    }

        

}
