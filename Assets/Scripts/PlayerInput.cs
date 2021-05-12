using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private SnakeMovement snakeMovement;

    private int horizontal = 0;
    private int vertical = 0;

    public enum Axis
    {
        Horizontal,
        Vertical
    }
    
    void Awake()
    {
        snakeMovement = GetComponent<SnakeMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = 0;
        vertical = 0;

        GetKeyboardInput();
        SetMovement(); 
        
    }

    void GetKeyboardInput()
    {
        horizontal = GetAxisRaw(Axis.Horizontal); // Doesnt go crazy 
        vertical = GetAxisRaw(Axis.Vertical);

        if (horizontal!=0)
        {
            vertical = 0;
        }
    }

    void SetMovement()
    {
        if (vertical!=0)
        {
            snakeMovement.SetDirection((vertical == 1) ? PlayerDirection.UP : PlayerDirection.DOWN);
        }
        else if (horizontal!=0)
        {
            snakeMovement.SetDirection((horizontal ==1) ? PlayerDirection.RIGHT : PlayerDirection.LEFT);
        }
    }

    int GetAxisRaw(Axis axis)
    {
        if(axis==  Axis.Horizontal)
        {
            bool left = Input.GetKeyDown(KeyCode.LeftArrow);
            bool right = Input.GetKeyDown(KeyCode.RightArrow);
            if (left)
            {
                return -1;
            }
            if (right)
            {
                return 1;
            }
            return 0;
        }
        else if(axis==Axis.Vertical)
        {
            bool up = Input.GetKeyDown(KeyCode.UpArrow);
            bool down = Input.GetKeyDown(KeyCode.DownArrow);

            if (down)
            {
                return -1;
            }
            if (up)
            {
                return 1;
            }
            return 0;
        }
        return 0;

    }

}
