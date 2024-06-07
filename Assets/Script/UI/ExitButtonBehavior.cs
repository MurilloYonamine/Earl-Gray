
using UnityEngine;

public class ExitButtonBehavior : ButtonBehavior /// sai do jogo
{
    public override void OnClick()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}



