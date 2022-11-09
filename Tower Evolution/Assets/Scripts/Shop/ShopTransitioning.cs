using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopTransitioning : MonoBehaviour
{
    private Animator shopTransitioning;
    private bool isClosed = true;

    void Start()
    {
        shopTransitioning = GameObject.Find("Shop Background").GetComponent<Animator>();
    }

    public void TransitionShop()
    {
        if (isClosed)
        {
            isClosed = false;
            shopTransitioning.SetTrigger("open");
            GetComponentInChildren<TextMeshProUGUI>().text = "Close";
            
            foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
            {
                tower.GetComponent<TowerUpgrading>().enabled = true;
            }
        }
        else
        {
            isClosed = true;
            Destroy(GameObject.FindGameObjectWithTag("Unspawned Tower"));
            shopTransitioning.SetTrigger("close");
            GetComponentInChildren<TextMeshProUGUI>().text = "Shop";

            foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
            {
                tower.GetComponent<TowerUpgrading>().enabled = false;
            }
        }
    }
}