using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public int idTank;
    public int iPuntos = 0;
    public float fTime = 120;
    public Text txtTime;
    public Text txtPuntos;
    public bool bInGame = false;
    public GameObject activeTank;
    public GameObject targetGO;
    public GameObject[] prefabsTanks;

    public Slider sldHead;
    public Slider sldCanon;
    GameObject tankGO;
    int segundos;

    private void Start()
    {
        // Instace tank
        tankGO = Instantiate(prefabsTanks[idTank]);
        tankGO.transform.parent = targetGO.gameObject.transform;
        tankGO.transform.localScale = new Vector3(1, 1, 1);
    }

    void Update () {
        if(bInGame && activeTank != null)
        {
            fTime -= Time.deltaTime;
            segundos = (int)Math.Truncate(fTime);
            txtTime.text = segundos.ToString();
            txtPuntos.text = iPuntos.ToString();
        }
    }

    public void HeadRotation()
    {
        if (bInGame && activeTank != null)
        {
            activeTank.GetComponent<TankController>().HeadRotation(-180 + sldHead.value);
        }
    }

    public void CanonRotation()
    {
        if (bInGame && activeTank != null)
        {
            activeTank.GetComponent<TankController>().CanonRotation(sldCanon.value);
        }
    }
}
