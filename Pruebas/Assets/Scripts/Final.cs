using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Final : MonoBehaviour
{
    private GameManager gameManager;

    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();

        textMeshProUGUI.text = gameManager.getMensajeFinal();
    }
}
