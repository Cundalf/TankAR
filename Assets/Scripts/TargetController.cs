using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour, ITrackableEventHandler
{
    
    public GameObject GameUI;
    public GameObject SyncUI;
    public Game gameScript;

    TrackableBehaviour mTrackableBehaviour;

    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            
            gameScript.activeTank = getTankGO();

            if(gameScript.activeTank != null)
            {
                // UI
                GameUI.SetActive(true);
                SyncUI.SetActive(false);

                gameScript.bInGame = true;
                gameObject.SetActive(true);
            }
            else
            {
                GameUI.SetActive(false);
                SyncUI.SetActive(true);
                gameScript.bInGame = false;
                gameObject.SetActive(false);
            }
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            // UI
            GameUI.SetActive(false);
            SyncUI.SetActive(true);

            gameScript.bInGame = false;
            gameScript.activeTank = null;
            gameObject.SetActive(false);
        }
        else
        {
            // UI
            GameUI.SetActive(false);
            SyncUI.SetActive(true);

            gameScript.bInGame = false;
            gameScript.activeTank = null;
            gameObject.SetActive(false);
        }
    }

    GameObject getTankGO()
    {
        for(int i = 0; i <= gameObject.transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).tag == "Player" )
            {
                return gameObject.transform.GetChild(i).gameObject;
            }
        }

        return null;
    }
}
