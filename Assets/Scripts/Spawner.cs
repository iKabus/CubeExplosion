using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Explosion _destruction;
    [SerializeField] private Cube _cube;

    private void OnMouseUpAsButton()
    {
        int minNumber = 2;
        int maxNumber = 7;
        int cubeNumber = Random.Range(minNumber, maxNumber);

        if (_cube.CanSplit())
        {
            for (int i = 0; i < cubeNumber; i++)
            {
                Create();
            }

            _destruction.Explode();
        }

        Destroy(_cube.gameObject);
    }

    private void Create()
    {
        Cube cube = Instantiate(_cube);

        cube.SetChance(_cube.CurrentChance);
        cube.ChangeColor();
        cube.ChangeScale();

        _destruction.AddToHits(cube);
    }
}
