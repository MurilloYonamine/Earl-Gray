using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GerenciadorDeEventos : MonoBehaviour
{
    public GerenciadorDeDialogos gerenciadorDeDialogos;
    private string nomeCenaDialogos;
    public string nomeCenaGameplay;
    public float delayAntesDaGameplay = 2.0f;

    void Start()
    {
        if (gerenciadorDeDialogos == null)
        {
            Debug.LogError("GerenciadorDeDialogos não foi atribuído.");
            return;
        }

        // Armazenar o nome da cena dos diálogos
        nomeCenaDialogos = SceneManager.GetActiveScene().name;

        Debug.Log("Iniciando sequencia de eventos...");
        StartCoroutine(SequenciaDeEventos());
    }

    private IEnumerator SequenciaDeEventos()
    {
        while (true)
        {
            // Esperar até que o diálogo atual esteja inativo
            yield return new WaitUntil(() => !gerenciadorDeDialogos.dialogos[gerenciadorDeDialogos.indiceDialogoAtual].activeSelf);

            // Carregar a cena de gameplay
            Debug.Log("Tentando carregar a cena de gameplay: " + nomeCenaGameplay);
            SceneManager.LoadScene(nomeCenaGameplay);

            // Esperar até que a cena de gameplay seja carregada
            yield return new WaitUntil(() => SceneManager.GetSceneByName(nomeCenaGameplay).isLoaded);
            Debug.Log("Cena de gameplay carregada: " + nomeCenaGameplay);

            // Esperar um pouco na cena de gameplay
            yield return new WaitForSeconds(delayAntesDaGameplay);

            // Descarregar a cena de gameplay
            Debug.Log("Descarregando a cena de gameplay: " + nomeCenaGameplay);
            SceneManager.UnloadSceneAsync(nomeCenaGameplay);

            // Voltar para a cena dos diálogos
            Debug.Log("Voltando para a cena dos diálogos: " + nomeCenaDialogos);
            SceneManager.LoadScene(nomeCenaDialogos);
        }
    }

    public void GameplayTerminou()
    {
        Debug.Log("Terminando gameplay e descarregando a cena de gameplay.");
        SceneManager.UnloadSceneAsync(nomeCenaGameplay);
    }

    public void PularGameplay()
    {
        Debug.Log("Pulando a gameplay.");
        GameplayTerminou();
    }
}
