using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lebensmanager : MonoBehaviour
{
    [SerializeField]
    private int playerHp = 10;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject newStartCanvas;
    [SerializeField]
    private GameObject moneyText;
    [SerializeField]
    private GameObject err;
    [SerializeField]
    private GameObject err2;
    private int coins = 36;
    private float time = 2f;
    private int maxHealth;
    private static Lebensmanager instance;
    public bool PlayerAlive
    {
        get
        {
            return playerHp > 0;
        }

    }
    public static Lebensmanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Lebensmanager> ();
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    public int Coins
    {
        get
        {
            return coins;
        }

        private set
        {
            coins = value;
        }
    }

    private void Start()
    {
        maxHealth = playerHp;
        BeginClaimCoins ();
    }
    private void Update ()
    {
        slider.value = CurrentLife ();
        slider.GetComponentInChildren<Text> ().text = playerHp.ToString () + "/" + maxHealth.ToString ();
        moneyText.GetComponent<Text> ().text = coins.ToString () + " Coins";
    }
    private IEnumerator ClaimCoins (float time)
    {
        while (PlayerAlive)
        {
        
            SetCoins (2);
            yield return new WaitForSeconds (time);
        }
    }
    private IEnumerator ActivateText ()
    {
        err.SetActive (true);
        yield return new WaitForSeconds (1f);
        err.SetActive (false);
    }
    private IEnumerator ActivateFinishUpdate ()
    {
        err2.SetActive (true);
        yield return new WaitForSeconds (1f);
        err2.SetActive (false);
    }
    public void SetCoins (int raise)
    {
        coins += raise;
    }
    private float CurrentLife() {
        return (float)playerHp / (float)maxHealth;
    }
    public void DecreaseLife ()
    {
        playerHp -= 1;
        Debug.Log ("PLaer hp" + playerHp);
        if (!PlayerAlive)
        {
            ShowCanvas (true);
        }
    }
    public void RaiseLife ()
    {
        if (Coins >= 10)
        {
            playerHp += 1;
            maxHealth += 1;
            SetCoins (-10);
        }
        else
        {
            BeginActivateText ();
        }
    }
    public void TimeClaimCoins (){
        if (Coins >= 10)
        {

            if (time > 0.2f)
            {
                time -= 0.2f;
                SetCoins (-10);
            }
            else
            {
                BeginActivateFinishupdate ();
            }
        }
        else
        {
            BeginActivateText ();
        }
    }
    public void BeginClaimCoins ()
    {
        StartCoroutine (ClaimCoins (time));
    }
    public void BeginActivateText ()
    {
        StartCoroutine (ActivateText());
    }
    public void BeginActivateFinishupdate ()
    {
        StartCoroutine (ActivateFinishUpdate ());
    }
    public void SetLife (int hp)
    {
        playerHp = hp;
    }
    public void ShowCanvas (bool show)
    {
        newStartCanvas.SetActive (show);
    }
    public void ResetMoney ()
    {
        coins = 36;
    }
}