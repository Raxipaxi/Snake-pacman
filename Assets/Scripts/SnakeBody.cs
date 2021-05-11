using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : iLinkedList
{
    Node head;
    Node tail;
    int count;

    public void Initialize()
    {
        head = new Node(null);
        tail = new Node(null);
        count = 0;
    }
    public void Add(Node node)
    {
        if (count==0)
        {
            head = tail = node;
            node.SetNext(null);
        }
        else
        {
            tail.SetNext(node);
            tail = node;
            node.SetNext(null);
        }
        count++;
    }
    public int GetCount()
    {
        return count;
    }
    public Node GetFirst()
    {
        return head;
    }    
    public Node GetLast()
    {
        return tail;
    }

    public int IndexOf(Rigidbody part)
    {
        Node current = head;
        int index = 1;
        if (part.Equals(head.GetPart()))
        {
            return 0;
        }
        else
        {
            while (current.GetNext() != null || current.GetPart().Equals(part))
            {
                current = current.GetNext();
                index++;
            }
            if (current.GetPart().Equals(part))
            {
                return index;
            }
            return -1;
        }
    }
    public Rigidbody GetPart(int index)
    {
        Rigidbody part =  null;
        Node current =  head;
        for (int i = 0; i < count; i++)
        {
            if (i==index)
            {
                part = head.GetPart();
            }
        }
        return part;
    }
    public void Insert(int index, Node node) //wont use it ¬¬
    {
        Node current = head;
        if (index==0)
        {
            node.SetNext(head);
            head = node;

        }
        else if (index== count)
        {
            tail.SetNext(node);
            node.SetNext(null);
            tail = node;
        }
        
        for (int i = 0; i < index; i++)
        {
            if (i==index-1)
            {
                node.SetNext(current.GetNext());
                current.SetNext(node);
            }
            current = current.GetNext();
        }
        count++;
    }

    public void Remove(Rigidbody part)
    {

        Node currentprev = head;

        int index = IndexOf(part);
        if (index == 0)
        {          
            head = head.GetNext();
        }
        else
        {
            for (int i = 0; i < index+1; i++)
            {
                if (i == index - 1)
                {
                    currentprev.SetNext(currentprev.GetNext().GetNext());
                    if (index == count-1)
                    {
                        tail = currentprev;
                    }
                }
                currentprev = currentprev.GetNext();
            }

        }
        count--;
    }

    public void RemoveAt(int index)
    {

        Node currentprev = head;

        if (index == 0)
        {

            head = head.GetNext();
        }
        else
        {
            for (int i = 0; i < index + 1; i++)
            {
                if (i == index - 1)
                {
                    currentprev.SetNext(currentprev.GetNext().GetNext());
                    if (index == count - 1)
                    {
                        tail = currentprev;
                    }
                }
                currentprev = currentprev.GetNext();
            }

        }
        count--;
    }
}
