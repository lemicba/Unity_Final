using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProccess : MonoBehaviour
{
    [SerializeField] private PostProcessVolume volume;

    private ColorGrading _colorGrading;
    private bool blackAndWhite = false;
    void Start()
    {
        volume.profile.TryGetSettings(out _colorGrading);
    }

    // Update is called once per frame
    void Update()
    {
        if (blackAndWhite == false) {
            if (Input.GetKeyDown(KeyCode.B)) {
                _colorGrading.saturation.value = -100;
                blackAndWhite = !blackAndWhite;
            }
        } else if (blackAndWhite == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                _colorGrading.saturation.value = 0;
                blackAndWhite = !blackAndWhite;
            }
        }
    }
}
