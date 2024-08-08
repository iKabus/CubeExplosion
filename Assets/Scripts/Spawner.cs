using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private Explosion _destruction;

    private int _chanceExplosion = 100;

    private void OnMouseUpAsButton()
    {
        int minNumber = 2;
        int maxNumber = 7;
        int denominator = 2;
        int cubeNumber = UnityEngine.Random.Range(minNumber, maxNumber);

        int maxChance = 100;
        int randomChance = UnityEngine.Random.Range(0, maxChance);

        if (_chanceExplosion > randomChance)
        {
            Vector3 position = _cube.transform.position;

            for (int i = 0; i < cubeNumber; i++)
            {
                GameObject cube = Instantiate(_cube, position, Quaternion.identity);

                ChangeScale(cube);

                ChangeColor(cube);
            }

            _chanceExplosion /= denominator;

            _destruction.Explode();

            Destroy(gameObject);
        }
    }

    private void ChangeColor(GameObject cube)
    {
        if (cube.TryGetComponent<Renderer>(out Renderer component))
        {
            component.material.color = UnityEngine.Random.ColorHSV();
        }
    }

    private void ChangeScale(GameObject cube)
    {
        int scaleChange = 2;

        cube.transform.localScale /= scaleChange;
    }
}
