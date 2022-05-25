using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i; 
    public bool shouldMoveWithoutPlayer = false;
    public bool onlyMoveOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldMoveWithoutPlayer)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.2f) //if reached next point
            {
                    i++; //move onto next point

                    if (i == points.Length) //if reached the end of points
                    {
                        if (!onlyMoveOnce) //prevents moving backwards and forwards if enabled in inspector
                        {
                            i = 0; //reset index
                        }
                        else
                        {
                            i = points.Length - 1; //set index to last point
                        }
                    }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); //move towards point
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        col.transform.SetParent(transform);
    }

    void OnCollisionExit2D (Collision2D col)
    {
        col.transform.SetParent(null);
    }
}
