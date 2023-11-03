using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Setup")]
    public float curHealth;
    public float maxHealth;
    public float curArmour;
    public float maxArmour;

    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider armourBar;

    private void Start()
    {
        UpdateHealth(maxHealth);
        UpdateArmour(maxArmour);
    }

    public void UpdateHealth(float amount)
    {
        curHealth += amount;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        healthBar.value = curHealth;
    }

    public void UpdateArmour(float amount)
    {
        curArmour += amount;
        curArmour = Mathf.Clamp(curArmour, 0, maxArmour);
        armourBar.value = curArmour;
    }
}
