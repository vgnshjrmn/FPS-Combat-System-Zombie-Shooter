using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMAnager : MonoBehaviour
{
    public GameObject playerCam;
   [SerializeField] float range = 50f;
    float damage = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f) return;
        if (PauseManager.instance.IsPaused)
            return;


        if (Input.GetButtonDown("Fire1"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.gunShot);
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position,transform.forward, out hit ,range))
        {
            EnemyManager enemy = hit.transform.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                enemy.Hit(damage);
            }

        }

    }
}
