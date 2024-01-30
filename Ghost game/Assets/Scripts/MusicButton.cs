using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    private AudioListener audiolistener;
    private static bool MusicOn = true;

    public void MusicOff()
    {
        MusicOn = !MusicOn;
    }
    public void Start()
    {
        audiolistener = GetComponent<AudioListener>();
    }
    public void Update()
    {
        audiolistener.enabled = MusicOn;
    }
}
