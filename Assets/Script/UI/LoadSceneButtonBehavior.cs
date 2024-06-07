
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButtonBehavior : ButtonBehavior // carregar uma nova cena
{
    [SerializeField] private string sceneName;
    public override void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
