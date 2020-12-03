using UnityEngine;
using UnityEngine.UI;

public class Backend : MonoBehaviour
{
    [HideInInspector] public static int enemiesDead;

    [Header("Variaveis de texto")]
    [SerializeField] private Text enemiesDeadText;

    private void Update()
    {
        enemiesDeadText.text = "Inimigos Mortos: " + enemiesDead.ToString();
    }
}