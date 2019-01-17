using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrowdController : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed = 20;
    [SerializeField]
    float _reachedLocationRadius = 5;

    public UnityEvent movedPeasants;

    public Queue<Peasant> peasants;

    public List<Path> paths;

    public void MovePeasants(int destinationPathIndex)
    {
        if (destinationPathIndex > paths.Count)
            return;

        movedPeasants.Invoke();
    }

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
