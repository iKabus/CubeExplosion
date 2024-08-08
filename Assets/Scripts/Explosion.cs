using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObgect())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Debug.Log("Boom!");
    }

    private List<Rigidbody> GetExplodableObgect()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> units = new();

        units.AddRange(hits.Where(hit => hit.attachedRigidbody != null).Select(hit => hit.attachedRigidbody));

        return units;
    }
}
