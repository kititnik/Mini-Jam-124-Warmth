using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic;
    [SerializeField] private float offset;
    private int _sortingOrderBase = 0;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y + offset);
        if (isStatic)
            Destroy(this);
    }
}