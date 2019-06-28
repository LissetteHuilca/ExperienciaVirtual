using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    //public Rigidbody2D body;
    public UnityEngine.SceneManagement.SceneManager escenas;
    public float walkingSpeed;
    public float jumpSpeed;

    public Transform trans;
    public Rigidbody2D body;
    public Animator anim;
    public GameObject image;
    

    // Start is called before the first frame update

    private void Awake()
    {
        trans = this.transform;
        body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { // y-axis movement
            body.velocity += jumpSpeed * Vector2.up;
            anim.SetTrigger("Jump");
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -walkingSpeed;

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
            { // Rotation around y-axis
                if (speed > 0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 0, 0);
                    //text.text = "Moving Right";
                }
                else if (speed < -0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 180, 0);
                    //text.text = "Moving Left";
                }
            }
            anim.SetFloat("Speed", Mathf.Abs(speed));
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherObject = collision.collider.gameObject;
        if (otherObject.tag == "Good")
        {
            GameObject.Destroy(otherObject);
        }
        
        if (otherObject.tag == "PortalA")
        {
            var position = this.transform.localPosition;
            position.x = -16f;
            position.y = -5.93f;
            this.transform.localPosition = position;
        }

        if (otherObject.tag == "PortalR")
        {
            SceneManager.LoadScene("Escena2"); 
        }

        if (otherObject.tag == "Bad")
        {
            var position = this.transform.localPosition;
            position.x = position.x - 2f;
            this.transform.localPosition = position;
        }

        if (otherObject.tag == "PortalD")
        {
            SceneManager.LoadScene("Final");
        }

        if (otherObject.tag == "PortalF")
        {
            //image = GameObject.Find("Panel");
            image.SetActive(true);
            
            
        }
    }
}

