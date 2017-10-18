using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour {
    [SerializeField]
    private GameObject monster;
    private Queue<GameObject> freeObjects = new Queue<GameObject>();
    public static MonsterPool Instance { get; private set; }
    // Use this for initialization
    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public GameObject GetFromPool() {
        if (freeObjects.Count == 0)
        {
            GrowPool();
        }
        GameObject instance = freeObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool() {
        for(int i=0; i < 10; i++)
        {
            GameObject newMonster = Instantiate(monster);
            newMonster.transform.SetParent(transform);
            AddToPool(newMonster);
        }
    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        freeObjects.Enqueue(instance);
    }
}
