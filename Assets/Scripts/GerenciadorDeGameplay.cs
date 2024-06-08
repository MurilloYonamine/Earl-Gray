using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GerenciadorDeGameplay : MonoBehaviour
{
    public string nomeCenaDialogos;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void TerminarGameplay()
    {
        Debug.Log("Gameplay terminada.");

        SceneManager.LoadScene(nomeCenaDialogos);
    }

    void Update()
    {
        // Lógica de teste para terminar a gameplay (pode ser substituída pela sua lógica real)
        if (Input.GetKeyDown(KeyCode.T))
        {
            TerminarGameplay();
        }

    }
}
