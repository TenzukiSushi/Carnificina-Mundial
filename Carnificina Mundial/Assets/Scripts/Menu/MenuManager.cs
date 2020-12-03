using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    Animator anim;

    private void Start() => anim = GetComponent<Animator>();

    public void StartGameTrigger() => anim.Play("StartGame");
    public void ExitGameTrigger() => anim.Play("ExitGame");

    public void ExitGame() => Application.Quit();
    public void GoToScene(string scene) => SceneManager.LoadScene(scene);
}
