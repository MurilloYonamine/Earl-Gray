using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI componenteTexto;
    [SerializeField] private TextMeshProUGUI componenteNome;
    [SerializeField] private List<string> falas;
    [SerializeField] private List<string> nome;
    [SerializeField] private float velocidadeTexto;
    private int index;

    void Start()
    {
        componenteTexto.text = string.Empty;
        componenteNome.text = string.Empty;
        ComecarDialogo();
    }
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (componenteTexto.text == falas[index] && componenteNome.text == nome[index])
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
        if (index >= falas.Count || index >= nome.Count)
        {
            Debug.LogError("Você precisa colocar mais texto ou nome.");
        }
        else
        {
            componenteNome.text = nome[index];
            index = 0;
            StartCoroutine(EscreverFala());
        }
    }
    // Efeito máquina de escrever
    IEnumerator EscreverFala()
    {
        foreach (char c in falas[index].ToCharArray())
        {
            componenteTexto.text += c;
            yield return new WaitForSeconds(velocidadeTexto);
        }
    }
    void ProximaFala()
    {
        if (index < falas.Count - 1)
        {
            index++;
            componenteTexto.text = string.Empty;
            componenteNome.text = nome[index];
            StartCoroutine(EscreverFala());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
