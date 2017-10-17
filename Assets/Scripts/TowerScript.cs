using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {
    [SerializeField]
    private GameObject monster;
    [SerializeField]
    private float regeneration =2f;
    [SerializeField]
    private float range = 6f;
    [SerializeField]
    private int damage = 2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position,monster.transform.position) < range)
        {
            monster.GetComponent<Monster>().SetHp (damage);
            StartCoroutine("Regeneration",regeneration);
        }
	}
    private IEnumerator Regeneration(float regeneration)
    {
        yield return new WaitForSeconds (regeneration);
    }
}
