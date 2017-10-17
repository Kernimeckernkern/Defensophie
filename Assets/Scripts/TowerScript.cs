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
        StartCoroutine ("Attack",regeneration);
	}

    // Update is called once per frame
    /*MIt collider die monster aufnehmen um sie dann richtig zu attakieren mit on trigger enter und ontriggerexit*/
    IEnumerator Attack (float regeneration)
    {
        while (true)
        {

            if (Vector3.Distance (transform.position, monster.transform.position) < range)
            {
                monster.GetComponent<Monster> ().SetHp (damage);
                yield return new WaitForSeconds (regeneration);
            }
        }
    }
}
