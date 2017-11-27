using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour {
    static MusicPlayerController instance = null;
	// Use this for initialization
	void Start () {
        if (instance != null) {
            Destroy(gameObject);
        } else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
