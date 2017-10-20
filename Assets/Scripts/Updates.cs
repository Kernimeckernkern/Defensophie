using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updates : MonoBehaviour {
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject err;
    [SerializeField]
    private TowerScript script;

    public void ExpandRange()
    {
        if (Lebensmanager.Instance.Coins >= 10)
        {
            script.SetRange (1f);
            Lebensmanager.Instance.SetCoins (-10);
        } else {
            Lebensmanager.Instance.BeginActivateText ();
        }
    }
    public void IncreaseDamage()
    {
        if (Lebensmanager.Instance.Coins >= 10)
        {
            script.SetDamage (1);
            Lebensmanager.Instance.SetCoins (-10);
        }
        else
        {
            Lebensmanager.Instance.BeginActivateText ();
        }
    }
    public void DecreaseRegeneration()
    {
        if (Lebensmanager.Instance.Coins >= 10)
        {
            if (script.Regeneration > 0.5f)
            {
                script.SetRegeneration (0.5f);
                Lebensmanager.Instance.SetCoins (-10);
            }
            else
            {
                Lebensmanager.Instance.BeginActivateFinishupdate ();
            }
        }
        else
        {
            Lebensmanager.Instance.BeginActivateText ();
        }
    }

    public void DeleteObj ()
    {
        script.ResetTower();
        gameObject.SetActive (false);
        button.transform.position -= new Vector3 (0f,130f,0f);
    }
}
