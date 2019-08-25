using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
       SceneManager.LoadScene("TestScene1");
    }

    public void onclickBWStart()
    {
        SceneManager.LoadScene("Tutorial1");
    }


}
