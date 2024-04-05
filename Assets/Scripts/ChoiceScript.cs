using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ChoiceScript : MonoBehaviour
{
    public Text TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public int ChoiceMade;

    private int currentQuestionIndex = 0;
    private int score = 0;

    private List<Question> questions = new List<Question>();

    private Camera mainCamera;
    private GraphicRaycaster graphicRaycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    void Start()
    {
        mainCamera = Camera.main;
        graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
        pointerEventData = new PointerEventData(eventSystem);

        // Add your questions here
        questions.Add(new Question("What is 2 + 2?", "3", "4", "5", 2));
        questions.Add(new Question("What is the capital of France?", "Paris", "Berlin", "London", 1));
        questions.Add(new Question("What is the largest planet in our solar system?", "Jupiter", "Saturn", "Earth", 1));

        ShowQuestion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForButtonPress();
        }
    }

    void CheckForButtonPress()
    {
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == Choice01)
            {
                ChoiceOption1();
                return;
            }
            else if (result.gameObject == Choice02)
            {
                ChoiceOption2();
                return;
            }
            else if (result.gameObject == Choice03)
            {
                ChoiceOption3();
                return;
            }
        }
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            TextBox.text = currentQuestion.question;
            Choice01.GetComponentInChildren<Text>().text = currentQuestion.choice1;
            Choice02.GetComponentInChildren<Text>().text = currentQuestion.choice2;
            Choice03.GetComponentInChildren<Text>().text = currentQuestion.choice3;
        }
        else
        {
            // All questions answered, display score
            TextBox.text = "Quiz completed!";
            TextBox.text += "\nYour score: " + score + " / " + questions.Count;
            DisableChoices();
        }
    }

    public void ChoiceOption1()
    {
        if (currentQuestionIndex < questions.Count)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            if (currentQuestion.correctChoice == 1)
            {
                score++;
            }
            currentQuestionIndex++;
            ShowQuestion();
        }
    }

    public void ChoiceOption2()
    {
        if (currentQuestionIndex < questions.Count)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            if (currentQuestion.correctChoice == 2)
            {
                score++;
            }
            currentQuestionIndex++;
            ShowQuestion();
        }
    }

    public void ChoiceOption3()
    {
        if (currentQuestionIndex < questions.Count)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            if (currentQuestion.correctChoice == 3)
            {
                score++;
            }
            currentQuestionIndex++;
            ShowQuestion();
        }
    }

    void DisableChoices()
    {
        Choice01.SetActive(false);
        Choice02.SetActive(false);
        Choice03.SetActive(false);
    }
}

public class Question
{
    public string question;
    public string choice1;
    public string choice2;
    public string choice3;
    public int correctChoice;

    public Question(string question, string choice1, string choice2, string choice3, int correctChoice)
    {
        this.question = question;
        this.choice1 = choice1;
        this.choice2 = choice2;
        this.choice3 = choice3;
        this.correctChoice = correctChoice;
    }
}
