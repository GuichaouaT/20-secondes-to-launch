using UnityEngine;

public class IsInRange : MonoBehaviour
{
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField] private UnityEventBool result;

    private void OnValidate()
    {
        if (min > max)
            min = max;
    }

    public void Check(float value) => result.Invoke(value <= max && value >= min);
}
