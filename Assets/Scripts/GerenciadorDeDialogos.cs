using UnityEngine;

public class GerenciadorDeDialogos : MonoBehaviour
{
    public GameObject[] dialogos; 
    public int indiceDialogoAtual = 0;

    void Start()
    {
        if (dialogos == null || dialogos.Length == 0)
        {
            Debug.LogError("Nenhum diálogo foi atribuído ao GerenciadorDeDialogos.");
            return;
        }
/*
        // Inicialmente, esconda todos os diálogos
        foreach (var dialogo in dialogos)
        {
            if (dialogo != null)
            {
                dialogo.SetActive(false);
            }
            else
            {
                Debug.LogError("Um dos diálogos no array é nulo.");
            }
        }

        // Mostre o primeiro diálogo
        if (dialogos[0] != null)
        {
            dialogos[0].SetActive(true);
        }
        else
        {
            Debug.LogError("O primeiro diálogo é nulo.");
        }*/
    }

    public void MostrarProximoDialogo()
    {
        // Esconde o diálogo atual
        if (indiceDialogoAtual < dialogos.Length && dialogos[indiceDialogoAtual] != null)
        {
            dialogos[indiceDialogoAtual].SetActive(false);
        }

        indiceDialogoAtual++;
        
        if (indiceDialogoAtual < dialogos.Length)
        {
            Debug.Log("Mostrando diálogo: " + indiceDialogoAtual);
            if (dialogos[indiceDialogoAtual] != null)
            {
                dialogos[indiceDialogoAtual].SetActive(true);
            }
            else
            {
                Debug.LogError("Diálogo atual é nulo.");
            }
        }
        else
        {
            Debug.Log("Não há mais diálogos.");
        }
    }

    public void EsconderDialogoAtual()
    {
        if (indiceDialogoAtual > 0 && indiceDialogoAtual < dialogos.Length)
        {
            if (dialogos[indiceDialogoAtual - 1] != null)
            {
                dialogos[indiceDialogoAtual - 1].SetActive(false);
            }
            else
            {
                Debug.LogError("Diálogo a esconder é nulo.");
            }
        }
    }
}
