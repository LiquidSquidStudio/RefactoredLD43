using UnityEngine.Events;

[System.Serializable]
public class ResourceEvent : UnityEvent<ResourceChange> { }

public class ResourceChange
{
    public ResourceType resource;
    public int amount;
}