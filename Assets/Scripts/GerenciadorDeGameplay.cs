using UnityEngine;

public class GerenciadorDeGameplay : MonoBehaviour
{
public void TerminarGameplay()
{
    Debug.Log("Gameplay terminada.");
    // Não há necessidade de chamar GerenciadorDeEventos nesta cena
}



    void Update()
    {
        // Lógica de teste para terminar a gameplay
        if (Input.GetKeyDown(KeyCode.T))
        {
            TerminarGameplay();
        }
    }
}
