using UnityEngine;

public enum ResourceType {
    Wood,
    Iron,
    Food,
    Weapon
}

public class ResourceManager : MonoBehaviour
{
    // Organise what resources are available, gain and loss and the like
    // Methods:
    //  - Adding int X to resource Y;
    //  - Setting resource Y to int X;
    //  - Initializing resources from ResourceState at beginning of scene
    //  - and saving resources from ResourceState at end of scene

        //  - Make weapon;                  Might move this to another script

    // Probs change the way this is setup at some point later on
    // Mixins and derived behaviours somewhere maybe

    #region Public Properties
    public int Wood
    {
        get
        {
            return _wood;
        }
    }
    public int Iron
    {
        get
        {
            return _iron;
        }
    }
    public int Food
    {
        get
        {
            return _food;
        }
    }
    public int Weapons
    {
        get
        {
            return _weapons;
        }
    }
    #endregion

    // Use a resource array/dictionary for better scaling??
    int _wood;
    int _iron;
    int _food;
    int _weapons;

    ResourceBuilding[] buildings;

    #region Design Fields
    [SerializeField]
    float foodPerPeasant = 0.5f;
    [SerializeField]
    int _woodRequiredForWeapon = 1;
    [SerializeField]
    int _metalRequiredForWeapon = 1;
    #endregion

    #region Event handling stuff
    // Clickable Building listener
    //List<ResourceBuilding> buildings;
    #endregion

    void Start()
    {
        InitializeResources();
        AddListenersToBuildings();
    }
    
    #region Saving and Loading Resources Methods on SceneChange

    private void OnDestroy()
    {
        SaveResourceState();
    }

    void InitializeResources()
    {
        ResourceState rs = FindObjectOfType<ResourceState>();
        _wood = rs.nWood;
        _iron = rs.nIron;
        _food = rs.nFood;
        _weapons = rs.nWeapons;
    }

    void SaveResourceState()
    {
        ResourceState rs = FindObjectOfType<ResourceState>();

        if (!rs)
            return;

        rs.nWood = _wood;
        rs.nIron = _iron;
        rs.nFood = _food;
        rs.nWeapons = _weapons;
    }
    #endregion

    void AddListenersToBuildings()
    {
        buildings = FindObjectsOfType<ResourceBuilding>();

        foreach (var building in buildings)
        {
            building.resourceEvent.RemoveListener(AddToResource);
            building.resourceEvent.AddListener(AddToResource);
        }
    }

    void AddToResource(ResourceChange rc)
    {
        var type = rc.resource;
        var nAdded = rc.amount;

        Debug.Log("Added " + nAdded + " " + type);

        switch (type)
        {
            case ResourceType.Wood:
                _wood += nAdded;
                break;
            case ResourceType.Iron:
                _iron += nAdded;
                break;
            case ResourceType.Food:
                _food += nAdded;
                break;
            case ResourceType.Weapon:
                MakeNWeapons(nAdded);
                break;
            default:
                break;
        }
    }

    public void SetResourceTo(ResourceType type, int setValue)
    {
        switch (type)
        {
            case ResourceType.Wood:
                _wood = setValue;
                break;
            case ResourceType.Iron:
                _iron = setValue;
                break;
            case ResourceType.Food:
                _food = setValue;
                break;
            case ResourceType.Weapon:
                _weapons = setValue;
                break;
        }
    }

    // Might move this to a separate script or something
    public void MakeNWeapons(int nWeapons)
    {
        bool runLoop = true;

        for (int i = 0; i < nWeapons; i++)
        {
            if (runLoop && _wood - _woodRequiredForWeapon < 0)
            {
                Debug.Log("Not enough wood to make a weapon");
                runLoop = false;
                return;
            }

            if (runLoop && _iron - _metalRequiredForWeapon < 0)
            {
                Debug.Log("Not enough metal to make a weapon");
                runLoop = false;
                return;
            }

            _wood -= _woodRequiredForWeapon;
            _iron -= _metalRequiredForWeapon;

            _weapons++;
        }
    }

}
