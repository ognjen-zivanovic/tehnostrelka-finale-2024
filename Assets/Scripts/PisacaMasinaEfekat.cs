using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PisacaMasinaEfekat : MonoBehaviour
{
    private string s;
    TMP_Text textComponent;

    IEnumerator TypingCoroutine()
    {
        var waitTimer = new WaitForSeconds(0.02f);
        foreach(char c in s)
        {
            textComponent.text += c;
            yield return waitTimer; 
        }

    }
    void Awake() {
        textComponent = GetComponent<TMP_Text>();
        textComponent.fontSizeMin = 10.0f;
    }

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.enableAutoSizing = false;
        s = textComponent.text;
        textComponent.text = "";
        StartCoroutine(TypingCoroutine());
    }
}
