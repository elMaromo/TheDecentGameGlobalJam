using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PavosCounter : MonoBehaviour
{
    public TextMeshProUGUI textPavos;


    public void Update()
    {
        int curerntPavos = PavosJugador.Instance.numPavos;
        textPavos.text = curerntPavos.ToString();
    }
}
