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

    // M�todo para exibir o pr�ximo objeto das listas
    void ShowNextObjects()
    {
        // Desativa o bot�o enquanto processa a exibi��o dos objetos
        nextButton.interactable = false;

        // Ativa o pr�ximo objeto da primeira lista
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

        // Ativa o pr�ximo objeto da segunda lista
        ShowObjectAtIndex(objects, index);

        // Reativa o bot�o ap�s o delay
        nextButton.interactable = true;
    }
}
