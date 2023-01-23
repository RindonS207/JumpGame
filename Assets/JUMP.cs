using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUMP : MonoBehaviour {

    public int POINTS = 0;
    bool HAHHA = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HAHHA)
        {
            HAHHA = true;
            this.POINTS += 1;
            Debug.Log("" + collision.collider.tag);
        }
        else { HAHHA = false; }
    }

    //void OnCollisionExit2D(Collision2D HHH)
    //{
    //    Debug.Log("test");
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("YOU WIN!");
    }

    // Use this for initialization
    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.WALK_CONTROL = GetComponent<Animator>();
	}

    float JUMP_ = 780.0f;
    float WALK_ZHONGLI = 30.0f;
    float MAX_SPEED = 2.0f;
    
    Rigidbody2D rigid2D;
    Animator WALK_CONTROL;

    // Update is called once per frame
    void Update () {
        

        int keys = 0;
        if (Input.GetKey(KeyCode.RightArrow)) { keys = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { keys = -1; }

        float MOVE_SPEED = Mathf.Abs(this.rigid2D.velocity.x);
        float JUMP_SPEED = Mathf.Abs(this.rigid2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(JUMP_SPEED == 0) { this.rigid2D.AddForce(transform.up * this.JUMP_); }
        }

        if (MOVE_SPEED < this.MAX_SPEED)
        {
            this.rigid2D.AddForce(transform.right * keys * this.WALK_ZHONGLI);
        }

        if(keys != 0)
        { transform.localScale = new Vector3(keys,1,1); }

        this.WALK_CONTROL.speed = MOVE_SPEED / 2.0f;
        if (this.WALK_CONTROL.speed == 0)
        { this.WALK_CONTROL.Play("PLAYER_WALK",0,0.0f); }
        
	}
}
