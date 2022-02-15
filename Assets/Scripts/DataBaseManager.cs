using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;
    public int InventarySpace;

    public List<Object> Invetary;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddObject(Object objecto)
    {
        if(Invetary.Count < InventarySpace)
        {
            Invetary.Add(objecto);
        } else
        {
            Debug.Log("No hay espacio");
        }

    }
    public void DeleteObject(Object objecto)
    {
        Invetary.Remove(objecto);
    }
}
