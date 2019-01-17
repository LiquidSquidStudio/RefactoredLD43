using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ResourceBuilding : MonoBehaviour
{
    [SerializeField]
    string _buildingName;
    BoxCollider2D _collider;

    [HideInInspector]
    public ResourceEvent resourceEvent;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider triggered");
        var stats = other.GetComponent<PeasantStats>();

        if (!stats)
            return;

        UseBuilding(stats);
    }

    void UseBuilding(PeasantStats stats)
    {
        BuildingAffect[] affects = GetComponents<BuildingAffect>();
        foreach (BuildingAffect affect in affects)
        {
            var rc = affect.Affect();

            rc.amount = Mathf.CeilToInt(rc.amount * stats.ResourceBonus((int)rc.resource));

            resourceEvent.Invoke(rc);
        }
    }
}
