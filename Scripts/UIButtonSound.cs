using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public void PlayClickSound()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }
}
