using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarParaOMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Menu");
    }
}
