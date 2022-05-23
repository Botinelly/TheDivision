using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int qntVida = 10;
    public Slider vidaSlider;
    private static LifeManager Instance = null;

    public static int actLife;

    void Start(){
        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy(gameObject); }
        vidaSlider.value = qntVida;
        actLife = qntVida;
    }

    public static void Dano(){
        Instance.vidaSlider.value -= 1;
        actLife -= 1;
    }   
}
