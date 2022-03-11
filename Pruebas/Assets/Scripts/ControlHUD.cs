using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI puntuacionTxt;

    public void setVidasTxt(int vidas)
    {
        vidasTxt.text ="Vidas:" + vidas;
    }

    public void setPuntuacionTxt(int cantidad)
    {
        puntuacionTxt.text = "Puntuacion:" + cantidad;
    }

}
