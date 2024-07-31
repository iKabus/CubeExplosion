using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    private int _chanceExplosion = 100;

    private void OnMouseUpAsButton()
    {
        int minNumber = 2;
        int maxNumber = 7;
        int cubeNumber = Random.Range(minNumber, maxNumber);
        
        int maxChance = 100;
        int randomChance = Random.Range(0, maxChance);

        Destroy(_gameObject);

        if (_chanceExplosion > randomChance)
        {
            Vector3 position = _gameObject.transform.position;

            ChangeScale();

            for (int i = 0; i < cubeNumber; i++)
            {
                Instantiate(_gameObject, position, Quaternion.identity);

                ChangeColor();
            }

            Explode();

            _chanceExplosion /= 2;
        }
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody == null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }

    private void ChangeColor()
    {
        _gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void ChangeScale()
    {
        int scaleChange = 2;

        _gameObject.transform.localScale /= scaleChange;
    }
}
