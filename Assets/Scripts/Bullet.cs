using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    GameObject ARCameraGO;
    Game gameScript;

    void Start()
    {
        ARCameraGO = GameObject.Find("ARCamera");
        gameScript = ARCameraGO.GetComponent<Game>();
    }

    void Update () {
	    if(gameObject.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameScript.iPuntos += 1;
            collision.gameObject.GetComponent<Duck>().Explode();
            //Destroy(collision.gameObject);
        }
    }
}
