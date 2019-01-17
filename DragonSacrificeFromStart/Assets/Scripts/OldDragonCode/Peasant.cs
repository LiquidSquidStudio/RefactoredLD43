using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class PeasantEvent : UnityEvent<Peasant> { }

public class Peasant : MonoBehaviour
{
    // Need to separate this out into the different system behaviours

        // PeasantMove
        // PeasantStats
        // Anything else?

    #region Properties
    public bool IsInTrasit { get; set; }
    public float MoveSpeed = 20;
    public float ReachedLocationRadius = 5;

    float _distance;
    Vector3 _target;
    //
    public CrowdController Controller { get; set; }

    public int Level { get; set; }
    public float StatBoostBonus { get; set; }
    public IEnumerable<MaterialResourceType> ResourceAffinity { get; set; }
    #endregion

    #region Implementation

    //private void Update()
    //{
    //    if (IsInTrasit)
    //        MovePeasant();

    //    if (IsInTrasit && HasReachedLocation())
    //        ReachedLocation();
    //}

    private void OnDisable()
    {
        IsInTrasit = false;

    }

    Vector3 CalculateDirection(Vector3 target)
    {
        return (target - transform.position).normalized;
    }

    public void Die()
    {
        //Controller.ResourceCore.RemovePeasant(this);
        Destroy(gameObject);
    }

    void MovePeasant()
    {
        var dir = CalculateDirection(_target);
        transform.Translate(dir * MoveSpeed * Time.deltaTime);
    }

    bool HasReachedLocation()
    {
        bool locCheck = false;

        _distance = (_target - transform.position).magnitude;

        if (_distance <= ReachedLocationRadius)
            locCheck = true;

        return locCheck;
    }
    #endregion

}
