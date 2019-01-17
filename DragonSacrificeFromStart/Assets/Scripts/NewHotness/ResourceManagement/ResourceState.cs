using UnityEngine;

// Feeling lazy, so just singletoning for total resources to be loaded to on scene start + altered on scene end
public class ResourceState : MonoBehaviour
{
    public static ResourceState instance;

    [HideInInspector]
    public int nWood { get; set; }
    [HideInInspector]
    public int nIron { get; set; }
    [HideInInspector]
    public int nFood { get; set; }
    [HideInInspector]
    public int nWeapons { get; set; }

    [SerializeField]
    int _startingFood = 30;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        InitializeResources();
    }

    void InitializeResources()
    {
        nWood = 0;
        nIron = 0;
        nFood = _startingFood;
        nWeapons = 0;
    }
}



// Do we really need all of this crap for keeping peasants as a resource??






//public GameResourceState(int nWoodResources = 0, int nIronResources = 0, int nFoodResources = 0, int nWeaponResources = 0)
//{
//    this.nWoodResources = nWoodResources;
//    this.nIronResources = nIronResources;
//    this.nFoodResources = nFoodResources;
//    this.nWeaponResources = nWeaponResources;
//}

//public class PeasantCrap
//{
//    public int nPeasants
//    {
//        get
//        {
//            return Peasants.Count();
//        }
//    }
//    public IEnumerable<Peasant> Peasants { get; private set; }

//    public void UpdatePeastants(IEnumerable<Peasant> peasants)
//    {
//        if (peasants == null)
//        {
//            throw new ArgumentNullException("peasants", "To update peasants, the list cannot be null");
//        }

//        Peasants = peasants;
//    }
//}
