using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> dialogos;

    void Update()
    {
        /*for (int i = 0; i < dialogos.Count; i++)
        {
            if (!dialogos[i].gameObject.activeSelf)
            {
                dialogos[i + 1].SetActive(true);
            }
        }*/

    }
}
