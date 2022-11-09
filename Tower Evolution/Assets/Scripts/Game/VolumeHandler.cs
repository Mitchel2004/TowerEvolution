using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeHandler : MonoBehaviour
{
    private float volume;

    void Update()
    {
        volume = GetComponentInParent<Slider>().value;

        GetComponent<TextMeshProUGUI>().text = $"Volume: {(int)volume}";
    }
}
