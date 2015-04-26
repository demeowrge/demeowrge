using UnityEngine;
using System.Collections;

public class CatSounds : MonoBehaviour {
    public AudioClip mur_1;
    public AudioClip burr_1;
    public int silenceChance;

    private AudioSource auPlayer;
	void Start () {
        auPlayer = gameObject.GetComponent<AudioSource>();
	}

    public void playBurr()
    {
        if (auPlayer != null)
        {
            auPlayer.clip = burr_1;
            auPlayer.Play();
        }
    }

    public void playMurr()
    {
        playSound(mur_1);
    }

    void playSound(AudioClip clip)
    {
        if (Random.Range(0, silenceChance) == 0)
        {
            auPlayer.clip = clip;
            auPlayer.Play();
        }
    }
}
