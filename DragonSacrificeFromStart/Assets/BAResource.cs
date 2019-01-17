// using UnityEngine; - In base class

public class BAResource : BuildingAffect
{
    public ResourceType resource;
    public int amount;

    ResourceChange rc;

    public override void Affect()
    {
        rc.resource = resource;
        rc.amount = amount;
    }
}
