using System.Collections;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] private Renderer cubeRenderer;
    [SerializeField] private Color sphereColor;
    [SerializeField] private bool isPainted;

    private Material[] _cubeMaterials;
    private Material _sphereMaterial;
    private Color _defaultSphereColor;
    private string _color = "_Color";
    private float _highlightedDuration = 3f;


    // Start is called before the first frame update
    void Awake()
    {
        _cubeMaterials = cubeRenderer.materials;
        _sphereMaterial = GetComponent<Renderer>().material;
        _defaultSphereColor = _sphereMaterial.GetColor(_color);
    }

    public IEnumerator HighlightPaintedSphere()
    {
        if (isPainted)
            _sphereMaterial.color = sphereColor;
        yield return new WaitForSeconds(_highlightedDuration);
        _sphereMaterial.color = _defaultSphereColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPainted)
        {
            GameController.DecreaseLife();
            if (GameController.Life <= 0)
                Destroy(other.gameObject);
        }
        else if (isPainted)
        {
            _sphereMaterial.color = sphereColor;
            _cubeMaterials[1].color = sphereColor;
            Destroy(gameObject);
        }
    }
}