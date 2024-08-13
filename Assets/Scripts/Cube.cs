using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _divider = 2f;

    private float _minChanceSplit = 0f;
    private float _maxChanceSplit = 100f;

    public float CurrentChance { get; private set; } = 100f;

    public void SetChance(float parentChance)
    {
        CurrentChance = parentChance / _divider;
    }

    public bool CanSplit()
    {
        float chance = Random.Range(_minChanceSplit, _maxChanceSplit);

        return CurrentChance >= chance;
    }

    public void ChangeColor()
    {
        if (TryGetComponent<Renderer>(out Renderer component))
        {
            component.material.color = Random.ColorHSV();
        }
    }

    public void ChangeScale()
    {
        int scaleChange = 2;

        transform.localScale /= scaleChange;
    }
}
