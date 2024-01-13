using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; }

    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    public HealthSystem healthSystem;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        slider.maxValue = healthSystem.MaxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        slider.value = healthSystem.CurrentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
