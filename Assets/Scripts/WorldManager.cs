using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldManager : MonoBehaviour
{
    public GameObject NormalWorld;
    public GameObject InsideWorld;
    public float changeDuration = 3f;
    public Player player;
    public Vector3 spawnPoint;
    public TransferToAnother TransferToAnother;
    // Start is called before the first frame update
    void Start()
    {

        NormalWorld.SetActive(true);
        InsideWorld.SetActive(false);
        spawnPoint = player.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDead){
            Debug.Log("Dead");
            //player.gameObject.SetActive(false);
            //player.transform.position = Vector3.Lerp(player.transform.position, spawnPoint, 0.5f);
            player.transform.DOMove(spawnPoint, 0.3f);  
            player.gameObject.SetActive(true);

            if(player.gameObject.transform.position.x >= spawnPoint.x && player.gameObject.transform.position.x <= spawnPoint.x+1){
                player.isDead = false;
            }
        }   
    }

    public void ChangeWorld(){
        // Animation
        if(NormalWorld.active){
            //TransferToAnother.ZoomInEffect();
            InsideWorld.SetActive(true);
            NormalWorld.SetActive(false);
            TransferToAnother.ZoomOutEffect();
            StartCoroutine(counter(changeDuration));
        }
    }

    IEnumerator counter(float d){
        yield return new WaitForSecondsRealtime(d);
        InsideWorld.SetActive(false);
        NormalWorld.SetActive(true);
        TransferToAnother.ZoomInToNormalEffect();
    }


}
