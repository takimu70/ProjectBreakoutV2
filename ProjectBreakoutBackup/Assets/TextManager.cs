using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{

    public static TextManager instance;
    public TMP_Text notifyText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        CloseText();
    }

    public void NotifyPlayer(string notification)
    {
        notifyText.gameObject.SetActive(true);
        notifyText.text = notification;
    }
    public void CloseText()
    {
        notifyText.gameObject.SetActive(false);
    }

}
