using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMusic;
    [SerializeField] private GameObject bossMusic;
    [SerializeField] private bool _check = true;

    public bool Check
    {
        get { return _check; }
        set { _check = value; }
    }

    public void PauseMusic()
    {
        if (_check)
        {
            mainMusic.SetActive(false);
        } else
        {
            bossMusic.SetActive(false);
        }
    }

    public void ResumeMusic()
    {
        if (_check)
        {
            mainMusic.SetActive(true);
        }
        else
        {
            bossMusic.SetActive(true);
        }
    }
}
