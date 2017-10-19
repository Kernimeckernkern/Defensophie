using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updates : MonoBehaviour {
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private TowerScript script;
    public void ExpandRange()
    {
        script.SetRange(1f);
    }
    public void IncreaseDamage()
    {
        script.SetDamage(1);
    }
    public void DecreaseRegeneration()
    {
        script.SetRegeneration(0.5f);
    }
    public void DeleteObj ()
    {
        script.ResetTower();
        gameObject.SetActive (false);
        button.transform.position -= new Vector3 (0f,130f,0f);
    }
}
