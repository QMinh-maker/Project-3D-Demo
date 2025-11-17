using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health Health;
    public Image HealthValue;
    private void Start()
    {
        if (Health != null)
        {
            Health.onHealthChanged.AddListener(UpdateHealthBar);
        }

        // Cập nhật thanh máu ban đầu
        UpdateHealthBar(Health.HealthPoint, Health.maxHealthPoint);
    }

    /// Hàm cập nhật thanh máu mỗi khi giá trị máu thay đổi.

    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (HealthValue != null)
        {
            HealthValue.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
