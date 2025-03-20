using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectPool", order = 1)]
public class ObjectPool : ScriptableObject
{
    [SerializeField] private uint PoolSize; 
    [SerializeField] private PooledObject objectToPool; 

    private Stack<PooledObject> stack; 

    public void Init()
    {
        stack = new Stack<PooledObject>(); 
        PooledObject instance = null; 

        for (int i = 0; i < PoolSize; i++)
        {
            instance = Instantiate(objectToPool); 
            instance.Pool = this; 
            instance.gameObject.SetActive(false); 
            stack.Push(instance);
        }
    }
    
    public PooledObject GetPooledObject()
    {
        Debug.Log("Get Pooled Object"); 
        if(stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this; 
            return newInstance; 
        }

        PooledObject nextObject = stack.Pop(); 
        nextObject.gameObject.SetActive(true);
        return nextObject; 
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject); 
        pooledObject.gameObject.SetActive(false); 
    }
}
