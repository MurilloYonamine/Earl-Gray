using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI componenteTexto;
    [SerializeField] private TextMeshProUGUI componenteNome;
    [SerializeField] private Image componenteImagem;  
    [SerializeField] private List<string> falas;
    [SerializeField] private List<string> nomes;
    [SerializeField] private List<Sprite> imagens;
    [SerializeField] private AudioSource audioSource;  // Usando o componente AudioSource diretamente
    [SerializeField] private float velocidadeTexto;
    private int index;

    void Start()
    {
        componenteTexto.text = string.Empty;
        componenteNome.text = string.Empty;
        componenteImagem.gameObject.SetActive(false);
        index = 0;  
        ComecarDialogo();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (componenteTexto.text == falas[index] && componenteNome.text == nomes[index])
            {
                ProximaFala();
            }
            else
            {
                StopAllCoroutines();
                componenteTexto.text = falas[index];
            }
        }
    }

    void ComecarDialogo()
    {
        if (index >= falas.Count || index >= nomes.Count || index >= imagens.Count)
        {
            Debug.LogError("Você precisa colocar mais texto, nomes ou imagens.");
        }
        else
        {
            componenteNome.text = nomes[index];
            AtualizarImagem();
            StartCoroutine(EscreverFala());
        }
    }

    IEnumerator EscreverFala()
    {
        foreach (char c in falas[index].ToCharArray())
        {
            componenteTexto.text += c;
            audioSource.PlayOneShot(audioSource.clip);  // Reproduz o som do componente AudioSource
            yield return new WaitForSeconds(velocidadeTexto);
        }
    }

    void ProximaFala()
    {
        if (index < falas.Count - 1)
        {
            index++;
            componenteTexto.text = string.Empty;
            componenteNome.text = nomes[index];
            AtualizarImagem();
            StartCoroutine(EscreverFala());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void AtualizarImagem()
    {
        if (imagens[index] != null)
        {
            componenteImagem.sprite = imagens[index];
            componenteImagem.gameObject.SetActive(true);
        }
        else
        {
            componenteImagem.gameObject.SetActive(false);
        }
    }
}
