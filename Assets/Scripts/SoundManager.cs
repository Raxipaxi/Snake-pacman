using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sounds;
    private AudioSource controlSound;
    // Start is called before the first frame update
    void Start()
    {
        controlSound = GetComponent<AudioSource>();
    }
    public void SetSound(int indice,float volume)
    {
        controlSound.PlayOneShot(sounds[indice], volume);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
