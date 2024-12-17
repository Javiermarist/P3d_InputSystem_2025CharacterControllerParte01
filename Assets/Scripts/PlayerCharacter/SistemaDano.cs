using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SistemaDano : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI textVidas;

    public int vida;

    public void RestarVida(int puntos)
    {
        vida -= puntos;
        Debug.Log("Que ta esho danio!");
        textVidas.text = "Vidas: " + vida;
        //textVidas.text = "Vidas: {vida}";
    }

    public int GetVida()
    {
        return vida;
    }
}
