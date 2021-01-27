using System;
using UnityEngine;
public abstract class ScriptableVariable<T> : ScriptableObject
{
    [SerializeField] private T value;
    [NonSerialized] public T Value;
    private void OnEnable() => Reset();

    public void Reset() => Value = value;
    //[CreateAssetMenu(fileName = "New Scriptable ... ", menuName = "Scriptable Assets/Variables/ ... ")]
}
