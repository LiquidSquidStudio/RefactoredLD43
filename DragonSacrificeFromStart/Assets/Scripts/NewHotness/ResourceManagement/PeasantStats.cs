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
    float[] _resourceBonuses;

    void Awake()
    {
        InitializeBonusStats();
    }

    public float ResourceBonus(int index)
    {
        float bonus = _resourceBonuses[index];
        return bonus;
    }

    void InitializeBonusStats()
    {
        _resourceBonuses = new float[_nTotalResourceTypes];

        if (_randomizeStats)
            for (int i = 0; i < _resourceBonuses.Length; i++)
                _resourceBonuses[i] = 1;
        else
            for (int i = 0; i < _resourceBonuses.Length; i++)
                _resourceBonuses[i] = 1 + Random.Range(-_bonusStdDeviation, _bonusStdDeviation);
    }
}
