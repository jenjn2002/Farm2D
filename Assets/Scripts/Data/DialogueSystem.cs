using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] Text targetText;
    [SerializeField] Text nameText;
    [SerializeField] Image portrait;

    DialogContainer currentDialogue;
    int currentTextLine;

    [Range(0f,1f)] 
    [SerializeField] float visibaleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    string lineToShow;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            PushText();
        }
        TypeOutText();
    }

    private void TypeOutText()
    {
        if (visibaleTextPercent >= 1f) { return; }
        currentTime += Time.deltaTime;
        visibaleTextPercent = currentTime / totalTimeToType;
        visibaleTextPercent = Mathf.Clamp(visibaleTextPercent, 0, 1f);

        UpdateText();
    }

    void UpdateText()
    {
        int letterCount = (int)(lineToShow.Length * visibaleTextPercent);
        targetText.text = lineToShow.Substring(0, letterCount);
    }

    private void PushText()
    {
        if(visibaleTextPercent < 1f)
        {
            visibaleTextPercent = 1f;
            UpdateText();
            return;
        }
        
        if(currentTextLine >= currentDialogue.line.Count) {
            Conclude();
        }
        else
        {
            CycleLine();
        }
    }

    void CycleLine()
    {
        lineToShow = currentDialogue.line[currentTextLine];
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibaleTextPercent = 0f;
        targetText.text = "";

        currentTextLine += 1;
    }

    public void Initalize(DialogContainer dialogContainer)
    {
        Show(true);
        currentDialogue = dialogContainer;
        currentTextLine = 0;
        CycleLine();
        UpdatePortrait();
    }

    private void UpdatePortrait()
    {
        portrait.sprite = currentDialogue.actor.portrait;
        nameText.text = currentDialogue.actor.Name;
    }

    private void Show(bool v)
    {
        gameObject.SetActive(v);
    }

    private void Conclude()
    {
        Debug.Log("end");
        Show(false);
    }
}
