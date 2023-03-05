using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource audioS;
    [SerializeField] AudioClip woosh;
    // Start is called before the first frame update
    void Start()
    {
        audioS = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWoosh()
    {
        audioS.PlayOneShot(woosh, 0.5f);
    }
}
