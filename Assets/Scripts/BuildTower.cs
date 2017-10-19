using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTower : MonoBehaviour {
    [SerializeField]
    private GameObject obj;

    private void Start ()
    {
        GetComponent<Button> ().onClick.AddListener (Build);
    }
    private void Build ()
    {
        obj.SetActive (true);
        obj.GetComponent<TowerScript>().BeginAttack ();
        transform.position += new Vector3 (0f,130f,0f);
    }
}
