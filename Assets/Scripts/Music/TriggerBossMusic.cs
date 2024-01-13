using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerBossMusic : MonoBehaviour
{
    [SerializeField] private GameObject mainMusic;
    [SerializeField] private GameObject bossMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MusicManager musicManager = collision.GetComponentInChildren<MusicManager>();
        mainMusic.SetActive(false);
        bossMusic.SetActive(true);
        musicManager.Check = false;
    }
}
