﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capture : MonoBehaviour
{
    public Slider CaptureSlider;
    public Image CaptureBar;

    public Gradient CaptureColor;

    public float CaptureMax = 100f;

    private float capture = 100f;
    private bool iScaptured = false;

    private void Start()
    {
        capture = CaptureMax;
        RefreshCapture();
    }

    private void FixedUpdate()
    {
        if (iScaptured)
        {
            capture = Mathf.Clamp(capture - Time.deltaTime * 4f, 0, CaptureMax);

            iScaptured = false;
        }
        else
        {
            capture = Mathf.Clamp(capture + Time.deltaTime * 2f, 0, CaptureMax);
        }

        RefreshCapture();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            iScaptured = true;
        }
    }

    public void RefreshCapture()
    {
        CaptureSlider.value = capture / CaptureMax;
        CaptureBar.color = CaptureColor.Evaluate(CaptureSlider.value);
    }
}
