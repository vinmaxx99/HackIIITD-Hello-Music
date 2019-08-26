using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectPositionHandler : MonoBehaviour
{

    public static List<TrackableBehaviour> objects;
    public static int idx = -1;
    int last = 0,p =0 ;
    float marker = 0;
    int cnt = 0;
    float currTime = 0;
   public float constTime = 0.03f;
    int ind = 0;
    AudioSource audio;
    public Material matA, matC, matD, matE, matA_red, matC_red, matD_red, matE_red;
    public GameObject D, A, C, E;


    private void Awake()
    {
        objects = new List<TrackableBehaviour>();

    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //p = Time.frameCount;
        //Debug.Log(p - last);
        //last = p;
        if (Time.frameCount % 10 == 0 )
        {
            objects.Sort(Compare);
            for (int i = 0; i < objects.Count; i++) {
                Debug.Log("HEllo "+ i + " "+ objects[i].TrackableName);
            }
        }

        currTime += Time.deltaTime;

        if (currTime >= marker)
        {
            marker += constTime;
            cnt++;
            //play function add
            Debug.Log("count " + cnt.ToString());
            if (objects.Count!=0 && (cnt-1)%(8/objects.Count)==0)
            {
                Debug.Log("Reached at " + cnt.ToString() );
                objects[(cnt-1)/(8/objects.Count)].GetComponent<AudioSource>().Play();
               // Destroy();
               // Create(objects[(cnt - 1) / (8 / objects.Count)].TrackableName);
            }

            //if(cnt<=objects.Count)
            //{
            //    Debug.Log("Reached at " + cnt.ToString());
            //    objects[cnt -1].GetComponent<AudioSource>().Play();
            //    Destroy();
            //    Create(objects[cnt - 1].TrackableName);
            //}
        }

       if(cnt==8)
        {
            Debug.Log("end of sequence ");
            //audio.Play();
            //audio.Play();
            cnt = 0;
            currTime = 0;
            marker = 0;
        }

        if (objects.Count != 0)
        {
            Debug.Log(objects[0].transform.position.ToString());
        }
         
    }

    public int Compare(TrackableBehaviour x, TrackableBehaviour y)
    {
        //if (x.TrackableName[0] != y.TrackableName[0])
        //{
        //    return 0;
        //}
        //else
        //{
        if (x.transform.position.y > y.transform.position.y)
        {
            return 1;
        }
        else
        {
            return 0;
        }
        //}
        //return 1;

    }


    //public class Comp : IComparer<TrackableBehaviour>
    //{

    //    public int Compare(TrackableBehaviour x, TrackableBehaviour y)
    //    {
    //        //if (x.TrackableName[0] != y.TrackableName[0])
    //        //{
    //        //    return 0;
    //        //}
    //        //else
    //        //{
    //            if (x.transform.position.y > y.transform.position.y)
    //            {
    //                return 1;
    //            }
    //            else
    //            {
    //                return 0;
    //            }
    //        //}
    //        //return 1;

    //    }
    //}

    private void Destroy()
    {
        A.GetComponent<Renderer>().sharedMaterial = matA;
        C.GetComponent<Renderer>().sharedMaterial = matC;
        D.GetComponent<Renderer>().sharedMaterial = matD;
        E.GetComponent<Renderer>().sharedMaterial = matE;
    }

    private void Create(string s)
    {
        switch (s)
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


}
