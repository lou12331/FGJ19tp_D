using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject NormalWorld;
    public GameObject InsideWorld;
    public float changeDuration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        NormalWorld.SetActive(true);
        InsideWorld.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWorld(){
        // Animation
        if(NormalWorld.active){
            InsideWorld.SetActive(true);
        NormalWorld.SetActive(false);
        StartCoroutine(counter(changeDuration));
        }
    }

    IEnumerator counter(float d){
        yield return new WaitForSecondsRealtime(d);
        InsideWorld.SetActive(false);
        NormalWorld.SetActive(true);
    }


}
