using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControlla : MonoBehaviour {

    public Sprite redflag;
    public Sprite greenflag;
    private SpriteRenderer checkpointspriterenderer;
    public bool checkpointreached;

	// Use this for initialization
	void Start () {
        checkpointspriterenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointspriterenderer.sprite = greenflag;
            checkpointreached = true;
        }
    }
}
