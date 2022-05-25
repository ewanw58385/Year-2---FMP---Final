using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDetectPlayer : MonoBehaviour
{
    public SpecialPlatform sp;
    public Rigidbody2D rb;

    void OnTriggerStay2D (Collider2D col)
    {
        sp = GetComponentInParent<SpecialPlatform>();
        
        if (col.tag == "Player") //if player touching and platform is not already moving
        {
            sp.shouldMoveWithoutPlayer = true;
        }
    }
}
