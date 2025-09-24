using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class QuizSystem : MonoBehaviour
{
    public InputTextSystem inputTextSystem;
    public GameObject startingQuiz;
    public GameObject quizStarted;
    public GameObject quizEnd;
    public GameObject kembali;
    public GameObject menyerah;
    public List<SoalSO> questions; // Soal-soal kuis
    public Text questionNumberText; // GameObject untuk menampilkan nomor soal
    public Text questionTextObject;
    public Button[] answerButtons;
    public Text feedbackText; // Text untuk menampilkan feedback
    public Text correctAnswerText; // Text untuk menampilkan jawaban yang benar
    public Text feedbackQuestionText;
    public GameObject feedbackPopup; // Pop-up untuk feedback
    public GameObject correctAnswerPopUp;
    public GameObject wrongAnswerPopUp;
    public Text namaEnd;
    public Text absenEnd;
    public Text keteranganEnd;
    public Text remLus;
    public GameObject BGLulus;
    public GameObject BGRemidi;
    private int currentQuestionIndex = 0;
    public int score = 0;
    public int scoreFinal = 0;
    void Start()
    {
        if (inputTextSystem == null)
        {
            Debug.Log("Input System not found");
        }
        StartingQuiz();
        if (questions.Count == 0)
        {
            Debug.LogError("Tidak ada soal di QuizSystem!");
            return;
        }
        else
        {
            Debug.Log("Jumlah Soal adalah " + questions.Count);
        }
        ShuffleQuestions();
        ShowQuestion();
    }
    void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            SoalSO temp = questions[i];
            int randomIndex = Random.Range(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }
    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count && currentQuestionIndex < 30) // Hanya tampilkan hingga 30 soal
        {
            SoalSO currentQuestion = questions[currentQuestionIndex];
            questionTextObject.text = currentQuestion.questionText;
            questionNumberText.text = "Soal " + (currentQuestionIndex + 1) + " dari 30";
            Debug.Log("Soal ke " + (currentQuestionIndex + 1));
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answers[i];
                int index = i; // Local copy for the closure
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
            }
        }
        else
        {
            EndQuiz();
        }
    }
    void OnAnswerSelected(int index)
    {
        string selectedAnswer = questions[currentQuestionIndex].answers[index];
        string correctAnswer = questions[currentQuestionIndex].answers[questions[currentQuestionIndex].correctAnswerIndex];
        if (index == questions[currentQuestionIndex].correctAnswerIndex)
        {
            feedbackQuestionText.text = questionTextObject.text;
            score++;
            correctAnswerPopUp.SetActive(true);
            wrongAnswerPopUp.SetActive(false);
            ShowFeedback("Jawabanmu Benar", "Dengan Jawaban " + correctAnswer + "  Tepat Sekali");
        }
        else
        {
            feedbackQuestionText.text = questionTextObject.text;
            correctAnswerPopUp.SetActive(false);
            wrongAnswerPopUp.SetActive(true);
            ShowFeedback("Jawabanmu Salah", "Dengan Jawaban " + selectedAnswer + "  Salah!!! " + "  Jawaban yang benar: " + correctAnswer);
        }
        currentQuestionIndex++;
    }
    void ShowFeedback(string message, string correctAnswer)
    {
        feedbackText.text = message;
        if (correctAnswer != null)
        {
            correctAnswerText.text = correctAnswer;
        }
        kembali.SetActive(false);
        menyerah.SetActive(true);
        quizStarted.SetActive(false);
        feedbackPopup.SetActive(true);
    }
    public void CloseFeedbackPopup()
    {
        kembali.SetActive(false);
        menyerah.SetActive(true);
        feedbackPopup.SetActive(false);
        quizStarted.SetActive(true);
        ShowQuestion();
    }
    void EndQuiz()
    {
        startingQuiz.SetActive(false);
        quizStarted.SetActive(false);
        quizEnd.SetActive(true);
        inputTextSystem.GetInputValue();

        string inputNamaText = inputTextSystem.inputNama;
        string inputNoAbsenText = inputTextSystem.inputNoAbsen;

        namaEnd.text = "Nama : " + inputNamaText;
        absenEnd.text = "No. Absen : " + inputNoAbsenText;

        scoreFinal = score * 100 / 30;
        if (scoreFinal < 60)
        {
            keteranganEnd.text = "Nilaimu Adalah: " + scoreFinal + " Tolong Remidi ya :)";
            remLus.text = "REMIDI";
            BGLulus.SetActive(false);
            BGRemidi.SetActive(true);
        }
        else
        {
            keteranganEnd.text = "Nilaimu Adalah: " + scoreFinal + " Yey kamu lulus";
            remLus.text = "LULUS";
            BGLulus.SetActive(true);
            BGRemidi.SetActive(false);
        }
    }
    public void StartingQuiz()
    {
        startingQuiz.SetActive(true);
        quizStarted.SetActive(false);
        quizEnd.SetActive(false);
        feedbackPopup.SetActive(false);
        kembali.SetActive(true);
        menyerah.SetActive(false);
    }
    public void QuizBegin()
    {
        startingQuiz.SetActive(false);
        quizStarted.SetActive(true);
        quizEnd.SetActive(false);
        feedbackPopup.SetActive(false);
        kembali.SetActive(false);
        menyerah.SetActive(true);
        score = 0;
        currentQuestionIndex = 0;
        ShowQuestion();
    }
}
