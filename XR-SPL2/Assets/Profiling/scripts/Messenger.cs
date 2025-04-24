using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Messenger", menuName = "Scriptable Objects/Messenger")]
public class Messenger : ScriptableObject
{
    public static UnityAction<int> OnObjectDestroyed; 

    public static void DestroyAnObject(int value)
    {
        OnObjectDestroyed?.Invoke(value);
    }
}
