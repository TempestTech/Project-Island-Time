using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject messagePanel;

    Text message;
    private GameObject lastEncounter;
    // Start is called before the first frame update
    void Start()
    {
        message = messagePanel.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMessagePanel(string text, GameObject _lastEncouter)
    {
        lastEncounter = _lastEncouter;
        message.text = text;
    }

    public void CloseMessagePanel(GameObject _lastEncounter)
    {
        if (lastEncounter == _lastEncounter)
            message.text = "";
    }
}
