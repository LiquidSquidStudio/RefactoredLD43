using UnityEngine;

// Doing it this way to enable multiple effects. Could eventually make this derive from a base class
public class BuildingAffect : MonoBehaviour
{
    [SerializeField]
    ResourceType resource;
    [SerializeField]
    int amount;

    public ResourceChange Affect()
    {
        ResourceChange rc = new ResourceChange();
        rc.resource = resource;
        rc.amount = amount;

        return rc;
    }
}
