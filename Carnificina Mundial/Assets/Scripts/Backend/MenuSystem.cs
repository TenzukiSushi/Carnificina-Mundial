using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void LoadScene(string name)
    {
        anim.Play("FadeOut");
        SceneManager.LoadScene(name);
        
    }
    public void ExitGame()
    {
        anim.Play("FadeOut");
        Application.Quit();
    }
}
