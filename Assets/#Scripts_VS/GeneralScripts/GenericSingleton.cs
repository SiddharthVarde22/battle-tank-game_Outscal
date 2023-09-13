using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if(Instance == null)
        {
            Instance = (T)this;
            // I do not want some of my Gameobjects to persist in every scene
            // but i want then to be singleton so others may access it easily
            // and i do not have to find the refrence of that object in all the classes that uses it
            // any class that i want to persist in multiple scenes overrides this method
            // that is why i have marked it as a virtual
        }
        else
        {
            Destroy(this);
            // or we can also do
            //Destroy(gameObject);
        }
    }
}
