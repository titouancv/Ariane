using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public GameObject healthBar;
    public Color goodColor;
    public Color middleColor;
    public Color badColor;
    public float maxHealth = 1f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        setColor(1);
    }
    public void SetDammages(float value)
    {
        healthBar.GetComponent<Scrollbar>().size -= value;
        float totalvalue = healthBar.GetComponent<Scrollbar>().size;
        setColor(totalvalue);
    } 

    void setColor(float value)
    {
        if (value >= 0.5f)
        {
            healthBar.transform.Find("mask").Find("sprite").GetComponent<Image>().color = goodColor;
        }
        else if (value < 0.5f && value >= 0.25f)
        {
            healthBar.transform.Find("mask").Find("sprite").GetComponent<Image>().color = middleColor;
        }
        else
        {
            healthBar.transform.Find("mask").Find("sprite").GetComponent<Image>().color = badColor;
        }
        
    }
}
