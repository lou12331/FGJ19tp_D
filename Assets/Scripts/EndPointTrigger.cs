using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audio;
    private BoxCollider2D box;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider2D>();
        audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            audio.enabled = true;
            audio.Play();
            //change scene
        }
    }
}
