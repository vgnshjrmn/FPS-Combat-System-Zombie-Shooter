using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float playerHealth = 100f;
    public TMP_Text playerHealthText;

    [SerializeField] Image damageIndicator;
    private void Start()
    {
        damageIndicator.gameObject.SetActive(true);
    }
    public void HealthDamage(float damage)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.playerHit);


        playerHealth -= damage;
        playerHealthText.text = "Health : " + playerHealth.ToString();
        ScreenFlashOnPlayerDamage();
        if (playerHealth <= 0)
        {
            GameManager.instance.EndTheGame();
            playerHealth = 100f;
            damageIndicator.gameObject.SetActive(false);
        }
    }
    Color c;
    public void ScreenFlashOnPlayerDamage()
    {
        c = damageIndicator.color;
        c.a = 0.6f;
        damageIndicator.color = c;
        Debug.Log("Blinking on " );
        StartCoroutine(FlashDelay());

    }
    IEnumerator FlashDelay()
    {
        yield return new WaitForSeconds(0.3f); 
        c.a = 0f;
        damageIndicator.color = c;
        Debug.Log("Blinking off");
    }
}
