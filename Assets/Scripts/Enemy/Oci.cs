using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oci : MonoBehaviour
{
    const float tau = Mathf.PI * 2;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;

        float rawSinWave = Mathf.Sin(cycles * tau);

        Vector3 offset = movementVector * rawSinWave;
        transform.position = startingPosition + offset;

    }
}
