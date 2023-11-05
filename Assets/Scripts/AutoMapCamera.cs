using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoMapCamera : MonoBehaviour
{
    RawImage image;

    private void Start()
    {
        image = GetComponent<RawImage>();
    }

    private void Update()
    {
        AutoMapDetection();
    }

    void AutoMapDetection()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            image.color = new Color(255, 255, 255, 150);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            image.color = new Color(255, 255, 255, 0);
        }
    }
}
