//using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrowdController : MonoBehaviour
{
    public UnityEvent movedPeasants;

    [SerializeField]
    Queue<Peasant> peasants = null;
    [SerializeField]
    List<Path> paths = null;

    [SerializeField]
    float _maxDelayTime = 0.3f;

    CrowdCreator cc;

    private void Awake()
    {
        cc = GetComponent<CrowdCreator>();
    }

    public void MoveNPeasants(int nPeasants, int pathIndex)
    {
        int nPInCrowd = cc.peasants.Count;

        #region Guardian clauses
        if (pathIndex > paths.Count)
        {
            Debug.Log("That path does not exist");
            return;
        }

        if (nPInCrowd == 0)
        {
            Debug.Log("No peasants in the crowd");
            return;
        }
        else if (nPeasants > nPInCrowd)
        {
            Debug.Log("There's not enough peasants in the crowd to move that many");
            nPeasants = nPInCrowd;
        }
        #endregion

        PopulatePeasantQueue(nPeasants);
        GivePeasantsPath(pathIndex);
        SetPeasantGroupMoving();

        movedPeasants.Invoke();
    }

    void PopulatePeasantQueue(int nPeasants)
    {
        for (int i = 0; i < nPeasants; i++)
        {
            var p = cc.peasants[0];
            peasants.Enqueue(p);
            cc.peasants.Remove(p);
        }

        Debug.Log("There are now " + peasants.Count + " peasants in the Controller queue");
    }

    void GivePeasantsPath(int pathIndex)
    {
        foreach (var p in peasants)
        {
            var qm = p.gameObject.GetComponent<QueueMovement>();

            foreach (var point in paths[pathIndex].PathPoints())
                qm.AddToQueue(point);

            Debug.Log("Peasant given path " + pathIndex + " to follow");
        }
    }

    void SetPeasantGroupMoving()
    {
        foreach (var p in peasants)
            StartCoroutine(PeasantMoveDelay(p));
    }

    #region Helpers

    // seems a bit hocky to have both of these passing in p....
    IEnumerator PeasantMoveDelay(Peasant p)
    {
        yield return new WaitForSeconds(RandomVariation(_maxDelayTime));
        SetPeasantMoving(p);
    }

    void SetPeasantMoving(Peasant p)
    {
        var qm = p.gameObject.GetComponent<QueueMovement>();
        qm.enabled = true;
    }

    float RandomVariation(float randScale)
    {
        float randomizedVar = Random.Range(0, randScale);
        return randomizedVar;
    }

    #endregion

    #region Old Code
    //public ResourceManagementCore ResourceCore;
    //public ResourceManagementUIManager UIManager;
    //[Space]

    //[Header("Spawn Points to wire up")]
    // Need to make and sort out a list of paths to the different locations. Also probs gizmo them up 
    //public List<Path> pathsToLocations;

    //#region MyRegion
    //private void Start()
    //{
    //    //if (PersistingData.storyProgression == 0)
    //    //{
    //    //    var spawnedPeasants = SpawnNPeasants(nPeasants);
    //    //    peasants = spawnedPeasants;
    //    //}
    //    //else
    //    //{
    //    //    nPeasants = PersistingData.gs.GetNumberOfPeasants();
    //    //    var spawnedPeasants = SpawnNPeasants(nPeasants);
    //    //    peasants = spawnedPeasants;
    //    //}
    //}
    //#endregion

    //private List<MaterialResourceType> AssignRandomAffinity(float affinityPercent)
    //{
    //    var result = new List<MaterialResourceType>();

    //    if (RandomChance(affinityPercent))
    //    {
    //        result.Add(SelectRandomResource());
    //    }

    //    return result;
    //}

    //private MaterialResourceType SelectRandomResource()
    //{
    //    int nResourceTypes = Enum.GetNames(typeof(MaterialResourceType)).Length;
    //    int randommIndex = (int)Random.Range(0.0f, nResourceTypes);
    //    return (MaterialResourceType)randommIndex;
    //}

    //private bool RandomChance(float chance)
    //{
    //    var comparer = Random.Range(0.0f, 100.0f);

    //    return (comparer <= chance);
    //}

    //[Header("Clickable Bulidings")]
    ////public ClickableBuildingController[] ClickableBuildings;
    ///

    //void MovePeasants()
    //{
    // get peasants from origin
    //int nPeasantsToMove = (int)CrowdSlider.value;

    // move them to new destination

    //foreach (var peasant in peasantsToMove)
    //{
    //    var destination = NoisyTransformPosition(GetPosition(newDestination), CrowdSizeScale);
    //    peasant.StartMoving(newDestination, destination);
    //}
    //}
    #endregion
}
