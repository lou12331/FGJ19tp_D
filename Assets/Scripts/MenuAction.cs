using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onclickStart()
    {
        Application.LoadLevel("TestScene1");
    }

    public void onclickBWStart()
    {
        Application.LoadLevel("Tutorial1");
    }


}
