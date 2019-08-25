using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instence;
    public bool isDead = false;
    public Movement movement;
    public Collider2D Collider2D;
    public Rigidbody2D Rigidbody2D;
    public TransferToAnother TransferToAnother;
    // Start is called before the first frame update
    private void Awake()
    {
        instence = this;
    }
    void Start()
    {
        movement = GetComponent<Movement>();
        Collider2D = GetComponent<Collider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "DeadArea"){
            isDead = true;
        }
    }
}
