using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetSimple : MonoBehaviour,ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private AudioSource audioClip;


    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

    }


    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if ((newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) && previousStatus == TrackableBehaviour.Status.NO_POSE)
        {
            //Debug.Log("YO " + mTrackableBehaviour.TrackableName +" " + mTrackableBehaviour.transform.position.ToString());

            //ObjectPositionHandler.objects.Add(mTrackableBehaviour);

        }

        if ((previousStatus == TrackableBehaviour.Status.DETECTED ||
             previousStatus == TrackableBehaviour.Status.TRACKED ||
             previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) && newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            audioClip.Play();
        }
    }
    
}
