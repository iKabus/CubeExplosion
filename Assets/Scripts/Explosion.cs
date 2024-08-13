using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private List<Collider> _hits = new();

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObgect())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    public void AddToArray(Cube cube)
    {
        if (TryGetComponent<Collider>(out Collider component))
        {
            _hits.Add(component);
        }
    }

    private List<Rigidbody> GetExplodableObgect()
    {
        List<Rigidbody> units = new();

        units.AddRange(_hits.Where(hit => hit.attachedRigidbody != null).Select(hit => hit.attachedRigidbody));

        return units;
    }
}
