using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GerenciadorDeGameplay : MonoBehaviour
{
    public string nomeCenaDialogos;

    void Start()
    {
        // Manter este objeto vivo ao mudar de cena
        DontDestroyOnLoad(gameObject);
    }

    public void TerminarGameplay()
    {
        Debug.Log("Gameplay terminada.");

        // Voltar para a cena dos diálogos
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
