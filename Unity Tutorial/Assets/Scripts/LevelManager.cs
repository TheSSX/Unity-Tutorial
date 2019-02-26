using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float respawndelay;
    public PlayerControlla gameplayer;

	// Use this for initialization
	void Start () {
        gameplayer = FindObjectOfType<PlayerControlla>();       //find GameObject which has the PlayerControlla script attached
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void respawn()
    {
        Debug.Log("This got called");
        StartCoroutine("respawnCoroutine");
    }

    public IEnumerator respawnCoroutine()
    {
        gameplayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawndelay);
        gameplayer.transform.position = gameplayer.respawnpoint;
        gameplayer.gameObject.SetActive(true);

    }
}
