using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/boolData")]
public class boolData : ScriptableObject
{
    public bool value;

    public void SetValue(bool valueChange)
    {
        value = valueChange;
    }
}