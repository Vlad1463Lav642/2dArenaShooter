using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthSlider;

    private void Awake()
    {
        healthSlider = gameObject.GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void AddHealth(int healValue)
    {
        healthSlider.value += healValue;
    }
}