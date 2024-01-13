using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;

    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindFirstObjectByType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }

    public void CharacterTookDamage(GameObject character, int damage)
    {
        Vector3 spawnPosition = character.transform.position + offset;

        TextMesh tmpText = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity)
            .GetComponent<TextMesh>();

        tmpText.text = damage.ToString();
    }

    public void CharacterHealed(GameObject character, int health)
    {
        Vector3 spawnPosition = character.transform.position + offset;

        TextMesh tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity)
            .GetComponent<TextMesh>();

        tmpText.text = health.ToString();
    }
}
