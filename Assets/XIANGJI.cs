using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XIANGJI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.PLAYER = GameObject.Find("cat");
	}

    GameObject PLAYER;
    bool BUTTON = false;
    bool JUMP = false;
	
	// Update is called once per frame
	void Update () {
        Vector3 PLAYER_POS = this.PLAYER.transform.position;

        if(PLAYER_POS.y < 0)
        { transform.position = new Vector3(transform.position.x, 0, transform.position.z); this.BUTTON = true; }
        else { this.BUTTON = true; this.JUMP = true; }
        if (PLAYER_POS.y > 13)
        { transform.position = new Vector3(transform.position.x, 13 , transform.position.z); this.BUTTON = true; }
        else { this.BUTTON = true; this.JUMP = true; }
        if (JUMP)
        {
            if (PLAYER_POS.y < 13 && PLAYER_POS.y > 0) { this.BUTTON = false; }
        }
        if (!BUTTON)
        { transform.position = new Vector3(transform.position.x, PLAYER_POS.y, transform.position.z); }
	}
}
