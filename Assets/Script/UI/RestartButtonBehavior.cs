using UnityEngine.SceneManagement;

public class RestartButtonBehavior : ButtonBehavior  // reinicia cena atual
{
    public override void OnClick()
    {
        int buildindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildindex);
    }
}