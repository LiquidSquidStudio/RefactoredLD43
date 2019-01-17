using UnityEngine;

public class ResourceBuilding : Building
{
    private void OnTriggerEnter(Collider other)
    {
        var stats = other.GetComponent<PeasantStats>();

        if (!stats)
            return;
    }

    //void InitializeResourceEffects()
    //{

    //}

    public override void BuildingUsed()
    {
        BuildingAffect[] affects = GetComponents<BuildingAffect>();
        foreach (BuildingAffect affect in affects)
        {
            affect.Affect();
        }
    }

}
