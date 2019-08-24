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
    public GameObject BloodParticle;
    public TransferToAnother TransferToAnother;///add by Haru
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
            player.isDead = false;
            //player.gameObject.SetActive(false);
            //player.transform.position = Vector3.Lerp(player.transform.position, spawnPoint, 0.5f);
            BloodParticle.transform.position = player.transform.position;
            BloodParticle.SetActive(true);
            BloodParticle.GetComponent<ParticleSystem>().Play();

            player.transform.DOMove(spawnPoint, 0.3f).OnStart(()=> onPlayerDeadStart()).OnComplete(()=>onPlayerDeadEnd());  
            player.gameObject.SetActive(true);

            if(player.gameObject.transform.position.x >= spawnPoint.x && player.gameObject.transform.position.x <= spawnPoint.x+1){
                
            }
        }   
    }
    void onPlayerDeadStart()
    {
        player.movement.canMove = false;
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().simulated = false;
    }
    void onPlayerDeadEnd()
    {
        player.movement.canMove = true;
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
    }

    public void ChangeWorld(){
        // Animation
        if(NormalWorld.active){
            TransferToAnother.ZoomOutEffect();///add by Haru
            InsideWorld.SetActive(true);
            NormalWorld.SetActive(false);
            StartCoroutine(counter(changeDuration));
        }
    }

    IEnumerator counter(float d){
        yield return new WaitForSecondsRealtime(d);
        InsideWorld.SetActive(false);
        NormalWorld.SetActive(true);
        TransferToAnother.ZoomInToNormalEffect();///add by Haru
    }


}
