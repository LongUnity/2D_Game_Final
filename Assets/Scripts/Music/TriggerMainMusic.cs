using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMainMusic : MonoBehaviour
{
    [SerializeField] private GameObject mainMusic;
    [SerializeField] private GameObject bossMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MusicManager musicManager = collision.GetComponentInChildren<MusicManager>();
        mainMusic.SetActive(true);
        bossMusic.SetActive(false);
        musicManager.Check = true;
    }
}
