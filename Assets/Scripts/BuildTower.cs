using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTower : MonoBehaviour {
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject err;
    private Updates updateScript;

    private void Start ()
    {
        updateScript = obj.GetComponent<Updates> ();
        GetComponent<Button> ().onClick.AddListener (Build);
    }
    private void Build ()
    {
        if (Lebensmanager.Instance.Coins >= 20)
        {
            obj.SetActive (true);
            obj.GetComponent<TowerScript> ().BeginAttack ();
            transform.position += new Vector3 (0f, 130f, 0f);
            Lebensmanager.Instance.SetCoins (-20);
        }
        else
        {
            Lebensmanager.Instance.BeginActivateText ();
        }
    }
}
