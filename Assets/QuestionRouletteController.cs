using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionRouletteController : MonoBehaviour
{
    [SerializeField] Text QuestionsText;
    [SerializeField] ImageSelector imageSelector;
    [SerializeField] TextTableItem tableSource;
    [SerializeField] float Interval = 0.05f;
    int NImages;
    int currentImage = 0;
    int NQuestions;
    int currentQuestion = 0;

    public delegate void OnSpinStoppedDelegate();

    public OnSpinStoppedDelegate OnSpinStopped;

    Coroutine SpinCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        QuestionsText.enabled = false;
        imageSelector.HideImage();
    }

    public void Initialize()
    {
        currentQuestion = 0;
        NImages = imageSelector.GetNumberOfImages();
        NQuestions = tableSource.GetNumberOfQuestions();
        Debug.Log("<color=blue> NQuestions: " + NQuestions + " </color>");
    }

    public void SpinRoulette()
    {
        Initialize();
        CycleQuestionAndImage();
        QuestionsText.enabled = true;
        imageSelector.ShowImage(0);
        SpinCoroutine = StartCoroutine(SpinRouletteCoRo());
    }

    public void HideAll()
    {
        QuestionsText.enabled = false;
        imageSelector.HideImage();
    }

    IEnumerator SpinRouletteCoRo()
    {
        while (1 < 2)
        {
            CycleQuestionAndImage();
            yield return new WaitForSeconds(Interval);
        }
    }

    private void CycleQuestionAndImage()
    {
        Debug.Log("QuestionRouletteController=> currentQuestion: " + currentQuestion);
        QuestionsText.text = tableSource.GetItem(currentQuestion, 0);
        imageSelector.ShowImage(currentImage);
        currentImage = (currentImage + 1) % NImages;
        currentQuestion = (currentQuestion + 1) % NQuestions;
    }

    public void StopRoulette()
    {
        if(SpinCoroutine != null)
        {
            StopCoroutine(SpinCoroutine);
        }
        StartCoroutine(StopRouletteCoRo());
    }

    IEnumerator StopRouletteCoRo()
    {
        float stoppingInterval = Interval;
        while (stoppingInterval < 0.22f)
        {
            CycleQuestionAndImage();
            yield return new WaitForSeconds(stoppingInterval);
            stoppingInterval += 0.025f;
        }
        OnSpinStopped?.Invoke();
    }
}
