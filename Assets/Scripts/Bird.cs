using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float upForce = 200f;

    private RotateBird rotateBird;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotateBird = GetComponent<RotateBird>();
    }

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    private void Update () {
        if (isDead)
            return;
        
        if (Input.GetMouseButtonDown(0)){
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * upForce);
            anim.SetTrigger("Flap");
            SoundSystem.instance.PlayFlap();
        }

        if (Input.GetMouseButtonDown(1)){
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.right * upForce);
            anim.SetTrigger("Flap");
            SoundSystem.instance.PlayFlap();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        Column col = collision.gameObject.GetComponent<Column>();
            if (!col.rotating){ // if not already rotating... 
                col.rotating = true; // I'm rotating 
                while (col.curAngle < 90)
                {
                    var dAngle = col.rotSpeed * Time.deltaTime; // how much to rotate this frame
                    col.curAngle += dAngle; // updates curAngle... 
                    this.transform.Rotate(0, dAngle, 0); // rotates object by the same angle yield;
                                                         // suspend rotation until next frame 
                }
                col.curAngle -= 90;
             // prepare for next 90 degrees rotation 
                col.rotating = false; // I'm not rotating anymore 
            }
        
        /* isDead = true;
         anim.SetTrigger("Die");
         rotateBird.enabled = false;
         GameController.instance.BirdDie();
         rb2d.velocity = Vector2.zero;*/
        //anim.SetTrigger("Flipant");
        SoundSystem.instance.PlayHit();
    }
}
