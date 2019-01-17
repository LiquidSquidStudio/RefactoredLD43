using UnityEngine;

public class PeasantStats : MonoBehaviour
{
    // Movement and resource multipliers for each peasant

    public float moveSpeed = 20f;
    public float reachLocRadius = 5f;
    [Space]

    [SerializeField]
    bool _randomizeStats = false;
    [SerializeField]
    float _bonusStdDeviation = .25f;
    int _nTotalResourceTypes = 4;

    [Space]
    public float[] resourceBonuses;

    QueueMovement _qm;

    void Awake()
    {
        InitializeBonusStats();
    }

    void Start()
    {
        _qm = GetComponent<QueueMovement>();

        if (_qm)
            InitializeMoveStats();
    }

    // Just including this here so that we can change things related to all stats on the peasants in one place
    // Also might move this the other way (access from the movement)
    void InitializeMoveStats()
    {
        _qm.moveSpeed = moveSpeed;

        // Might change this up since we're going the collider route atm
        _qm.reachedLocRadius = reachLocRadius;
    }

    void InitializeBonusStats()
    {
        resourceBonuses = new float[_nTotalResourceTypes];

        if (_randomizeStats)
            for (int i = 0; i < resourceBonuses.Length; i++)
                resourceBonuses[i] = 1;
        else
            for (int i = 0; i < resourceBonuses.Length; i++)
                resourceBonuses[i] = 1 + Random.Range(-_bonusStdDeviation, _bonusStdDeviation);
    }
}
