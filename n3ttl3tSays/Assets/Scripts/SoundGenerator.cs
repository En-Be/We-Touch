using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioLowPassFilter))]
public class SoundGenerator : MonoBehaviour
{
    private float sampling_frequency = 48000;

    [Range(0f, 1f)]
    public float noiseRatio = 0.5f;

    //for noise part
    [Range(-1f, 1f)]
    public float offset;

    public float cutoffOn = 800;
    public float cutoffOff = 100;

    public bool cutOff;

    //for tonal part

    public float frequency = 440f;
    public float gain = 0.05f;

    private float increment;
    private float phase;

    //for beat adjustment
    private int count = 0;
    private int currentBeat = 0;
    public float[] volumelevels;
    private AudioChorusFilter audioFilter;

    System.Random rand = new System.Random();
    AudioLowPassFilter lowPassFilter;

    void Awake()
    {
        audioFilter = GetComponent<AudioChorusFilter>();
        sampling_frequency = AudioSettings.outputSampleRate;

        lowPassFilter = GetComponent<AudioLowPassFilter>();
        Update();
    }



    void OnAudioFilterRead(float[] data, int channels)
    {
        float tonalPart = 0;
        float noisePart = 0;

        // update increment in case frequency has changed
        increment = frequency * 2f * Mathf.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i++)
        {
            
            //noise
            noisePart = noiseRatio * (float)(rand.NextDouble() * 2.0 - 1.0 + offset);

            phase = phase + increment;
            if (phase > 2 * Mathf.PI) phase = 0;


            //tone
            tonalPart = (1f - noiseRatio) * (float)(gain * Mathf.Sin(phase));


            //together
            data[i] = noisePart + tonalPart;

            // if we have stereo, we copy the mono data to each channel
            if (channels == 2)
            {
                data[i + 1] = data[i];
                i++;
            }   
        }    
    }

    void Update()
    {
        lowPassFilter.cutoffFrequency = cutOff ? cutoffOn : cutoffOff;
        audioFilter.dryMix -= 0.05f;
        audioFilter.dryMix = Mathf.Clamp(audioFilter.dryMix, 0, 1);
        audioFilter.wetMix1 -= 0.05f;
        audioFilter.wetMix1 = Mathf.Clamp(audioFilter.wetMix1, 0, 1);
        audioFilter.wetMix2 -= 0.05f;
        audioFilter.wetMix2 = Mathf.Clamp(audioFilter.wetMix2, 0, 1);
        audioFilter.wetMix3 -= 0.05f;
        audioFilter.wetMix3 = Mathf.Clamp(audioFilter.wetMix3, 0, 1);
    }

    public void Emit(Vector3 position, int beat)
    {
        if(beat == 0)
        {
            count = 0;
            currentBeat = 0;
        }

        if(beat > currentBeat)
        {
            {
                count++;
                currentBeat = beat;
            }

            if(count > 2)
            {
                count = 0;
            }

        }

        audioFilter.dryMix = volumelevels[count];
        audioFilter.wetMix1 = volumelevels[count];
        audioFilter.wetMix2 = volumelevels[count];
        audioFilter.wetMix3 = volumelevels[count];
    }

}