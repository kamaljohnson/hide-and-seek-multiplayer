using System.Collections.Generic;
using UnityEngine;

public enum EquippableObjectType
{
    None,   //nothing is equipped
    Book
}

public class EquippableObjectCollection : MonoBehaviour
{
    public static EquippableObjectCollection instance;

    public List<EquippableObject> prefabs;

    public void Start()
    {
        instance = this;
    }

    public GameObject GetPrefab(EquippableObjectType type)
    {
        return prefabs.Find(x => x.type == type).gameObject;
    }
}
