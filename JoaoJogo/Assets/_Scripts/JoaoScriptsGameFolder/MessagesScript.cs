using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagesScript : MonoBehaviour
{
    // Lista de GameObjects que pode ser preenchida pelo Inspector
    public List<GameObject> objectsToCycle1;
    public List<GameObject> objectsToCycle2;

    // Botão que será clicado para alternar entre os objetos
    public Button nextButton;

    // Índices atuais dos objetos a serem exibidos
    private int currentIndex1 = 0;
    private int currentIndex2 = 0;

    void Start()
    {
        // Configura o botão para chamar o método ShowNextObjects ao ser clicado
        nextButton.onClick.AddListener(ShowNextObjects);

        // Desativa todos os objetos nas listas
        foreach (GameObject obj in objectsToCycle1)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectsToCycle2)
        {
            obj.SetActive(false);
        }
    }

    // Método para exibir o próximo objeto das listas
    void ShowNextObjects()
    {
        // Desativa o botão enquanto processa a exibição dos objetos
        nextButton.interactable = false;

        // Ativa o próximo objeto da primeira lista
        ShowObjectAtIndex(objectsToCycle1, currentIndex1);

        // Avança para o próximo índice da primeira lista
        currentIndex1 = (currentIndex1 + 1) % objectsToCycle1.Count;

        // Inicia a corrotina para mostrar o próximo objeto da segunda lista após 1 segundo
        StartCoroutine(ShowNextObjectWithDelay(objectsToCycle2, currentIndex2, 1f));

        // Avança para o próximo índice da segunda lista
        currentIndex2 = (currentIndex2 + 1) % objectsToCycle2.Count;
    }

    // Método para mostrar o objeto com o índice fornecido
    void ShowObjectAtIndex(List<GameObject> objects, int index)
    {
        // Ativa o objeto atual
        objects[index].SetActive(true);
    }

    // Corrotina para mostrar o próximo objeto da lista após um atraso
    IEnumerator ShowNextObjectWithDelay(List<GameObject> objects, int index, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Ativa o próximo objeto da segunda lista
        ShowObjectAtIndex(objects, index);

        // Reativa o botão após o delay
        nextButton.interactable = true;
    }
}
