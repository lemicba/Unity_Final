using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour
{
    public Rigidbody trapRB;
    public Transform[] trapPositions;
    public float trapSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    // Update is called once per frame
    void Update()
    {
        MoveTrap();
    }

    void MoveTrap()
    {
        trapRB.MovePosition(Vector3.MoveTowards(trapRB.position, trapPositions[nextPosition].position, trapSpeed * Time.deltaTime));
        if(Vector3.Distance(trapRB.position, trapPositions[nextPosition].position) <= 0)
        {
            actualPosition = nextPosition;
            nextPosition++;

            if(nextPosition > trapPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }
}
