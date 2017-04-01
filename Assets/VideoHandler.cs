using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoHandler : MonoBehaviour {

    public MovieTexture movieTexture;
    public AudioSource audioHandler;
    public bool IsPlaying
    {
        get
        {
            return movieTexture.isPlaying;
        }
    }

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture = movieTexture;
        audioHandler.clip = movieTexture.audioClip;
        audioHandler.Play();
        movieTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Pause()
    {
        movieTexture.Pause();
        audioHandler.Pause();

    }
    public void Play()
    {
        movieTexture.Play();
        audioHandler.Play();
    }
    public void Stop()
    {
        movieTexture.Stop();
        audioHandler.Stop();
    }
    public void Replay()
    {
        Stop();
        Play();
    }
}
