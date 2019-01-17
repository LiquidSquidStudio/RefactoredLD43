using System;
using UnityEngine;

public class SobStoryContainer : MonoBehaviour
{
    public SobStory[] sobStories;

}

[Serializable]
public class SobStory
{
    // Could extend this class to include more bits and pieces about 
    //the individual story tellers

    public string StoryTellerName;
    public string SobStoryText;
    public string Response;
}
