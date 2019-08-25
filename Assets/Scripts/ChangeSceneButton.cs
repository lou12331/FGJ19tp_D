using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeSceneButton : MonoBehaviour
{
    public string changeSceneName = "";
    public Text changeSceneText = null;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        EventTrigger trigger = btn.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        // 鼠标点击事件
        entry.eventID = EventTriggerType.PointerClick;
        // 鼠标进入事件 entry.eventID = EventTriggerType.PointerEnter;
        // 鼠标滑出事件 entry.eventID = EventTriggerType.PointerExit;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(OnClick);
        // entry.callback.AddListener (OnMouseEnter);
        trigger.triggers.Add(entry);
    }

    public void init(string realSceneName)
    {
        changeSceneName += realSceneName;
        changeSceneText.text = realSceneName;
    }

    void OnClick(BaseEventData pointData)
    {
        WorldManager.instance.LoadScene(changeSceneName,false);
    }
}
