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
    public float curStamina;
    public float maxStamina;

    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider armourBar;
    [SerializeField] private Slider staminaBar;

    private void Start()
    {
        UpdateHealth(maxHealth);
        UpdateArmour(maxArmour);
        UpdateStamina(maxStamina);
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

    public void UpdateStamina(float amount)
    {
        curStamina += amount;
        curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
        staminaBar.value = curStamina;
    }
}
