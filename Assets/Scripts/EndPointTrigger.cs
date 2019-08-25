using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audio;
    private BoxCollider2D box;
    private bool endStage = false;
    public string nextSceneName;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider2D>();
        audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(endStage && !audio.isPlaying){
            endStage = false;
            //SceneManager.LoadScene(nextSceneName); 
            WorldManager.instance.LoadScene(nextSceneName, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Movement>().canMove = false;
            endStage = true;
            audio.enabled = true;
            audio.Play();
        }
    }

}
