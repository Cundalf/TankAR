using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {

    public GameObject[] duckPrefabs;
    public Game gameScript;

    GameObject duckPrefab;
    int indexPrefab;
    float time;

	void Update () {

         
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 
            && gameScript.bInGame 
            && transform.parent.gameObject.activeSelf)
        {
            time += Time.deltaTime;

            if( time > 2)
            {
                createDuck();
                time = 0;
            }
        }
        else
        {
            time = 0;
        }
	}

    void createDuck()
    {
        indexPrefab = Random.Range(0, duckPrefabs.Length);
        duckPrefab = duckPrefabs[indexPrefab];
            
        var duck = Instantiate(duckPrefab, gameObject.transform);

        Vector3 newPosition = getRandomPosition();
        Debug.Log(newPosition);
        duck.transform.localPosition = newPosition;
    }

    Vector3 getRandomPosition()
    {
        float newZ = Random.Range(0.3f, 1f);
        float newX = Random.Range(-0.3f, 0.3f);

        return new Vector3(newX, 0, newZ);
    }
}
