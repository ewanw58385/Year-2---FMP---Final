using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour
{
    public float speed;
    
    public Transform[] points;
    public int i = 0;
    
    public bool keyPickedUp;
    public bool shouldMoveWithoutPlayer = false;
    public bool onlyMoveOnce = true;
    [HideInInspector] public bool shouldMove = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
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

            if (i == 2)
            {
                shouldMove = false;

                if (keyPickedUp  && transform.GetChild(1) != null) //if key picked up and player has jumped back on platform
                {
                    shouldMove = true;
                }
            }

            if (shouldMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); //move towards point
            }
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
