using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private SnakeMovement mainBody;
    void Start()
    {
        mainBody = GetComponentInParent<SnakeMovement>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        mainBody.OnTriggerEnter(other);
    }
}
