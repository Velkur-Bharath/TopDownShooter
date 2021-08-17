using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public float shakeduration, shakeamplitude, shakefrequency;
    private float shakeelapsetime;
    public CinemachineVirtualCamera virtualcamera;
    private CinemachineBasicMultiChannelPerlin virtualcameranoise;

    // Start is called before the first frame update
    void Awake()
    {
        virtualcameranoise = virtualcamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeelapsetime > 0)
        {
            virtualcameranoise.m_AmplitudeGain = shakeamplitude;
            virtualcameranoise.m_FrequencyGain = shakefrequency;
            shakeelapsetime -= Time.deltaTime;
        }
        else
        {
            virtualcameranoise.m_AmplitudeGain = 0;
            shakeelapsetime = 0;
        }
    }

    public void shakeitlow()
    {
        shakeamplitude = 0.1f;

        shakeelapsetime = shakeduration;
    }

    public void shakeitmedium()
    {
        shakeamplitude = 0.2f;

        shakeelapsetime = shakeduration;
    }
}
