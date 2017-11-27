﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonController : MonoBehaviour {

	public void Quit ()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
