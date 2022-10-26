using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FramesCounter : MonoBehaviour
{
    private float frames;

    void Start()
    {
        InvokeRepeating("Count", 0, 1);
    }

    void Count()
    {
        frames = 1 / Time.unscaledDeltaTime;

        GetComponent<TextMeshProUGUI>().text = $"{(int)frames}\tFPS";
    }
}