using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagesScript : MonoBehaviour
{
    // Lista de GameObjects que pode ser preenchida pelo Inspector
    public List<GameObject> objectsToCycle1;
    public List<GameObject> objectsToCycle2;

    // Bot�o que ser� clicado para alternar entre os objetos
    public Button nextButton;

    // �ndices atuais dos objetos a serem exibidos
    private int currentIndex1 = 0;
    private int currentIndex2 = 0;

    void Start()
    {
        // Configura o bot�o para chamar o m�todo ShowNextObjects ao ser clicado
        nextButton.onClick.AddListener(ShowNextObjects);

        // Mostra apenas o primeiro objeto da lista 1 no in�cio
        ShowObjectAtIndex(objectsToCycle1, currentIndex1);
    }

    // M�todo para exibir o pr�ximo objeto das listas
    void ShowNextObjects()
    {
        // Mostra o pr�ximo objeto da primeira lista
        ShowObjectAtIndex(objectsToCycle1, currentIndex1);

        // Avan�a para o pr�ximo �ndice da primeira lista
        currentIndex1 = (currentIndex1 + 1) % objectsToCycle1.Count;

        // Inicia a corrotina para mostrar o pr�ximo objeto da segunda lista ap�s 1 segundo
        StartCoroutine(ShowNextObjectWithDelay(objectsToCycle2, currentIndex2, 1f));

        // Avan�a para o pr�ximo �ndice da segunda lista
        currentIndex2 = (currentIndex2 + 1) % objectsToCycle2.Count;
    }

    // M�todo para mostrar o objeto com o �ndice fornecido
    void ShowObjectAtIndex(List<GameObject> objects, int index)
    {
        // Ativa o objeto atual
        objects[index].SetActive(true);
    }

    // Corrotina para mostrar o pr�ximo objeto da lista ap�s um atraso
    IEnumerator ShowNextObjectWithDelay(List<GameObject> objects, int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowObjectAtIndex(objects, index);
    }
}
