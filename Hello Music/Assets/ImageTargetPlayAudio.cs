using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPlayAudio : MonoBehaviour, ITrackableEventHandler

{
    private TrackableBehaviour mTrackableBehaviour;
    private AudioSource audioClip;
    private static List<string> objectsName = new List<string>();
    public static int idx = -1;
    private static List<string> names;
    public Material matA, matC, matD,matE, matA_red, matC_red, matD_red,matE_red;
    public GameObject D, A, C,E;

    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
    names = new List<string>();
        names.Add("a");
        names.Add("c");
        names.Add("e");
        names.Add("d");
        names.Add("c");
        names.Add("a");
        names.Add("e");
        names.Add("d");
        names.Add("e");

    }


public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
{


    if ((previousStatus == TrackableBehaviour.Status.DETECTED ||
         previousStatus == TrackableBehaviour.Status.TRACKED ||
         previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) && newStatus == TrackableBehaviour.Status.NO_POSE)
    {
        // Stop audio when target is 
        char curr = mTrackableBehaviour.TrackableName[0];
        if (idx == -1)
        {
            audioClip.Play();
            NextArrow();
        }
        else if (curr == names[idx][0])
        {

            audioClip.Play();
            NextArrow();
        }
    }
}
private void Destroy()
{
    A.GetComponent<Renderer>().sharedMaterial = matA;
    C.GetComponent<Renderer>().sharedMaterial = matC;
    D.GetComponent<Renderer>().sharedMaterial = matD;
    E.GetComponent<Renderer>().sharedMaterial = matE;
}

private void Create()
{
    switch (names[idx])
    {
        case "a":
            A.GetComponent<Renderer>().sharedMaterial = matA_red;
            return;
        case "c":
            C.GetComponent<Renderer>().sharedMaterial = matC_red;
            return;
        case "d":
            D.GetComponent<Renderer>().sharedMaterial = matD_red;
            return;
        case "e":
            E.GetComponent<Renderer>().sharedMaterial = matE_red;
            return;
    }
}
public void NextArrow()
{
    Destroy();
    idx = (idx + 1) % 6;
    Create();
}


}
