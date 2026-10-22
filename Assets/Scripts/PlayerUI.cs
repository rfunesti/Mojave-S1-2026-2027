using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Health playerHealth;
    public Image[] heartImages;
    int health = 0;

    void Awake()
    {
        playerHealth = FindFirstObjectByType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerHealth) return;

        if (health != playerHealth.healthAmount) UpdateHealth();
    }

    void UpdateHealth()
    {
        health = playerHealth.healthAmount;
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < health) heartImages[i].enabled = true;
            else heartImages[i].enabled = false;
        }
    }
}