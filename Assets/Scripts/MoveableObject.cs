using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{

    private float speed = 0.5f;
    private Vector3 movement;
    RaycastHit hit;
    bool colliderHitByRaycast;

    public void MoveObject(string direction)
    {
        if (CanMove(direction))
        {
            switch (direction)
            {
                case "right":
                    transform.forward = Vector3.right;
                    movement.Set(speed, 0.0f, 0.0f);
                    break;
                case "left":
                    transform.forward = Vector3.left;
                    movement.Set(-speed, 0.0f, 0.0f);
                    break;
                case "up":
                    transform.forward = Vector3.forward;
                    movement.Set(0.0f, 0.0f, speed);
                    break;
                case "back":
                    movement.Set(0.0f, 0.0f, -speed);
                    transform.forward = Vector3.back;
                    break;
            }



            transform.position += movement;
        }
    }

    bool CanMove(string direction)
    {
        switch (direction)
        {
            case "right":
                Debug.DrawRay(transform.position, Vector3.right * speed, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.right, out hit, speed);
                break;
            case "left":
                Debug.DrawRay(transform.position, Vector3.left * speed, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.left, out hit, speed);
                break;
            case "back":
                Debug.DrawRay(transform.position, Vector3.back * speed, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.back, out hit, speed);
                break;
            case "up":
                Debug.DrawRay(transform.position, Vector3.forward * speed, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.forward, out hit, speed);
                break;
            default:
                Debug.DrawRay(transform.position, Vector3.forward * speed * 3, Color.blue, 3);
                break;
        }
        return !colliderHitByRaycast || hit.collider.isTrigger;
    }
}

