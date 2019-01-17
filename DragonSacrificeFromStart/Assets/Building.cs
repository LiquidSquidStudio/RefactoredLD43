using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Building : MonoBehaviour
{
    [SerializeField]
    string _buildingName;
    Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    public virtual void BuildingUsed()
    {

    }
}
