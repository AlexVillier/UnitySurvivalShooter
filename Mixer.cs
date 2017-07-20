using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour {

    public AudioMixer master;

    public void SetMusic(float musicLvl)
    {
        master.SetFloat("music", musicLvl);
    }

    public void SetFX(float fxLvl)
    {
        master.SetFloat("fx", fxLvl);
    }
}
