using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour {

    public GameObject headGO;
    public GameObject CanonControllerGO;
    public GameObject BulletRespawnGO;

    BulletController BulletScript;

    void Start () {
        BulletScript = BulletRespawnGO.GetComponent<BulletController>();
    }

    public void Fire(float fPower)
    {
        if(fPower == 0) { return; }
        BulletScript.Fire(fPower);
    }

    public void HeadRotation(float fRotation)
    {
        headGO.transform.localRotation = Quaternion.Euler(0, fRotation, 0);
    }

    public void CanonRotation(float fRotation)
    {
        CanonControllerGO.transform.localRotation = Quaternion.Euler(fRotation, 0, 0);
    }
}
