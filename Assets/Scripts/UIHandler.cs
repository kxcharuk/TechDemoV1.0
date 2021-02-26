using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Text keys;
    [SerializeField] GameObject player;
    [SerializeField] Slider healthSlider;
    int maxHealth;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = player.GetComponent<HealthSystem>().Health;
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<HealthSystem>().Health;
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;
        keys.text = player.GetComponent<Player>().Keys.ToString();
    }
}
