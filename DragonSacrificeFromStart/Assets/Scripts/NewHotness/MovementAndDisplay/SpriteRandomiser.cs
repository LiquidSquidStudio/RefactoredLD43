using UnityEngine;

[RequireComponent(typeof(SpriteContainer))]
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRandomiser : MonoBehaviour
{
    private SpriteRenderer sr;
    private SpriteContainer sc;

    private void Awake()
    {
        InitializeComponents();
    }

    void Start()
    {
        RandomiseSprite();
    }

    public void RandomiseSprite()
    {
        if (sc.SCNumSprites() == 0)
        {
            sr.enabled = false;
            return;
        }

        sr.sprite = sc.GetSprite(Rand());
    }

    int Rand()
    {
        int rand = Random.Range(0, sc.SCNumSprites());
        return rand;
    }

    private void InitializeComponents()
    {
        sr = GetComponent<SpriteRenderer>();
        sc = GetComponent<SpriteContainer>();
    }
}
