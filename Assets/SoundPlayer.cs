using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.Soundy;

public class SoundPlayer : MonoBehaviour
{
    public string Label;
    public SoundyData TestData;

    public void Play()
    {
        SoundyManager.Play(TestData);
    }
}
