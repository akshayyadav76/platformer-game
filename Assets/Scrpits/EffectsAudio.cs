using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] effectsAudioList;
    [Range(0,1)][SerializeField] float volum;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update(){
        audioSource.volume = volum;
    }

    public void hitEnemey()
    {
        audioSource.PlayOneShot(effectsAudioList[0]);
    }
    public void enemyExplod()
    {
        audioSource.PlayOneShot(effectsAudioList[1]);
    }
}
