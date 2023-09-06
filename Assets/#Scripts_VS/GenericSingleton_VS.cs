using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton_VS<T> : MonoBehaviour where T : GenericSingleton_VS<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if(Instance == null)
        {
            Instance = (T)this;
        }
        else
        {
            Destroy(this);
            // or we can also do
            //Destroy(gameObject);
        }
    }
}
