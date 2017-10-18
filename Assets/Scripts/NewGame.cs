using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {
    [SerializeField]
    private Spawner spawner;
    [SerializeField]
    private TowerScript towerScript;
    private void Start ()
    {
        GetComponent<Button> ().onClick.AddListener(NewStart);
    }
    private void NewStart (){
        spawner.Reset ();
        towerScript.Reset ();
        Lebensmanager.Instance.SetLife (10);
        Lebensmanager.Instance.ShowCanvas (false);
        towerScript.BeginAttack ();
        spawner.BeginSpawn ();
    }
}
