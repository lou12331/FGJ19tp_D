using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAction : MonoBehaviour
{
    public GameObject StartObj = null;
    public GameObject MenuObj = null;
    public GameObject TutorialBtnParent = null;
    public GameObject StageBtnParent = null;
    public string TutorialSceneName = "Tutorial";
    public string StageSceneName = "Stage";
    public int RowBtnCount = 7;
    public int TutorialBtnOffestX = 380;
    public int StageBtnOffestX = 250;
    public int BtnOffestY = 110;
    public GameObject TutorialBtn = null;
    public GameObject StageBtn = null;
    // Start is called before the first frame update
    void Start()
    {
        StartObj.SetActive(true);
        MenuObj.SetActive(false);
    }

    public void clickStart()
    {
        StartObj.SetActive(false);
        initMenu();
        MenuObj.SetActive(true);
    }

    void initMenu()
    {
        string tempSceneName = "";
        GameObject temp = null;
        RectTransform tempRect;
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            tempSceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            Debug.Log(tempSceneName);
            if (tempSceneName.IndexOf(TutorialSceneName) >= 0)
            {
                tempSceneName = tempSceneName.Replace(TutorialSceneName, "");
                Debug.Log(tempSceneName);
                temp = GameObject.Instantiate(TutorialBtn);
                temp.transform.parent = TutorialBtnParent.transform;
                tempRect = temp.GetComponent<RectTransform>();
                tempRect.localPosition = new Vector3(0 + TutorialBtnOffestX * ((int.Parse(tempSceneName) - 1) / RowBtnCount),
                    -100 - BtnOffestY * ((int.Parse(tempSceneName) - 1) % RowBtnCount),0);
                temp.GetComponent<ChangeSceneButton>().init(tempSceneName);
            }
            else if (tempSceneName.IndexOf(StageSceneName) >= 0)
            {
                tempSceneName = tempSceneName.Replace(StageSceneName, "");
                temp = GameObject.Instantiate(StageBtn);
                temp.transform.parent = StageBtnParent.transform;
                tempRect = temp.GetComponent<RectTransform>();
                tempRect.localPosition = new Vector3(0 + StageBtnOffestX * ((int.Parse(tempSceneName) - 1) / RowBtnCount),
                    -100 - BtnOffestY * ((int.Parse(tempSceneName) - 1) % RowBtnCount),0);
                temp.GetComponent<ChangeSceneButton>().init(tempSceneName);
            }
        }
    }
}
