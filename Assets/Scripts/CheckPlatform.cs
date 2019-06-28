using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour
{
    private player play;
    // Start is called before the first frame update
    void Start()
    {
        play = GetComponentInParent<player>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Plataforma")
        {
            play.transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Plataforma")
        {
            play.transform.parent = null;
        }
    }
}