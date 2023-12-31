using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrandma : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;

    int NextPosIndex;
    Transform nextPos;

    private bool hasChanged = false;
    private float roomChange = 0;
    private float waitTimeIn = 0.5f;
    private float waitTimeOut = 1f;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

    void MoveGameObject()
    {
        if (transform.position == nextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            nextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, ObjectSpeed * Time.deltaTime);
        }
    }
}
