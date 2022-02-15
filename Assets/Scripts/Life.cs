using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject[] Heart;
    public Queue<GameObject> HeartLine = new Queue<GameObject>();
    public static Life heart;
    void Start()
    {
        heart = this;
        foreach (GameObject g in Heart)
        {
            HeartLine.Enqueue(g);
            g.gameObject.SetActive(true);
        }
    }

    public void ReduceHeart()
    {
        GameObject g = HeartLine.Dequeue();
        g.gameObject.SetActive(false);
        HeartLine.Enqueue(g);

    }
}
