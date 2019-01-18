using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdCreator : MonoBehaviour
{
    public List<Peasant> peasants;

    [Range(0, 200)]
    public int nPeasants = 100;

    [SerializeField]
    Transform crowdLoc = null;
    [SerializeField]
    GameObject peasantPrefab = null;

    void Awake()
    {
        peasants.Clear();
    }

    void Start()
    {
        for (int i = 0; i < nPeasants; i++)
        {
            CreatePeasant();
        }
    }

    void CreatePeasant()
    {
        var peasant = Instantiate(peasantPrefab, crowdLoc.position,this.transform.rotation,this.gameObject.transform);
        peasants.Add(peasant.GetComponent<Peasant>());
    }

    #region Helpers
    Vector3 NoisyTransformPosition(Vector3 centrePoint, float scale)
    {
        Vector3 positionalNoise = new Vector2(RandNorm(scale), RandNorm(scale));

        Vector3 newPosition = centrePoint;
        newPosition += positionalNoise;
        return newPosition;
    }
    
    float RandNorm(float scale)
    {
        float u1 = 1 - Random.value;
        float u2 = 1 - Random.value;

        float randomNum = Mathf.Sqrt(-2 * Mathf.Log(u1)) * Mathf.Sin(2 * Mathf.PI * u2);
        randomNum = scale * randomNum;
        return randomNum;
    }
    #endregion

    //public List<Peasant> SpawnNPeasants(int n)
    //{
    //    var result = new List<Peasant>();

    //    for (int i = 0; i < n; i++)
    //    {
    //        var peasant = SpawnPeasant(ResourceLocation.CrowdPit);
    //        result.Add(peasant);
    //    }

    //    return result;
    //}

    //public Peasant SpawnPeasant(ResourceLocation location)
    //{
    //    Vector3 spawnPoint = GetPosition(location);
    //    GameObject peasant = Instantiate(peasantPrefab, NoisyTransformPosition(spawnPoint, CrowdSizeScale), Quaternion.identity, transform);
    //    var p = peasant.GetComponent<Peasant>();

    //    int level = 0;
    //    float statBoost = GenerateRandomStatBoost(_statBoostMax);
    //    var affinity = AssignRandomAffinity(_affinityChancePercent);
    //    bool transit = false;

    //    p.Level = level;
    //    p.CurrentLocation = location;
    //    p.StatBoostBonus = statBoost;
    //    p.ResourceAffinity = affinity;
    //    p.IsInTrasit = transit;
    //    p.MoveSpeed = _moveSpeed;
    //    p.ReachedLocationRadius = _reachedLocationRadius;
    //    p.Controller = this;

    //    return p;
    //}
}
