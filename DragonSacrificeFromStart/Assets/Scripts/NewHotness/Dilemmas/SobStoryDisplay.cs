using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SobStoryDisplay : MonoBehaviour
{
    // Take the sobstories within the container, and display 2 of them

    // Sort out the 2 buttons for the choices

    // Leave the next button to a separate thing

    public Text sobSText;
    public Button[] choiceButtons;

    [SerializeField]
    float textSpeed;
    [SerializeField]
    int activeChoiceIndex = 0;

    SobStoryContainer ssc;

    private void Awake()
    {
        ssc = GetComponent<SobStoryContainer>();
    }

    public void InitializeChoiceButtons()
    {
        for (int i = 0; i < 1; i++)
        {
            int ssIndex = (activeChoiceIndex * 2) +i;
            SobStory ss = GetSobStory(ssIndex);

            choiceButtons[i].GetComponentInChildren<Text>().text = ss.StoryTellerName;
            choiceButtons[i].onClick.AddListener(() => ShowResponse(ssIndex));
        }
    }

    void ShowResponse(int ssIndex)
    {
        string response = GetSobStory(ssIndex).Response;
        UpdateDisplay(response);
    }

    void UpdateDisplay(string textToDisplay)
    {
        sobSText.text = textToDisplay;
    }

    SobStory GetSobStory(int ssIndex)
    {
        return ssc.sobStories[ssIndex];
    }

    void EnableDisableButtons(bool buttonActive, bool goActive)
    {
        foreach(var button in choiceButtons)
        {
            button.gameObject.SetActive(goActive);
            button.GetComponent<Button>().enabled = buttonActive;
        }
    }
}
