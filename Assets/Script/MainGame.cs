using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public string SceneSimulation;
    public GameObject splashGameObject;
    public GameObject materiListGameObject;
    public GameObject listPart1GameObject;
    public GameObject listPart2GameObject;
    public GameObject listPart3GameObject;
    public GameObject listNext;
    public GameObject listBack;
    public GameObject materiTampilGameObject;
    public GameObject menuGameObject;
    public GameObject puzzleGameObject;
    public GameObject quizGameObject;
    public GameObject quizStartGameObject;
    public GameObject quizRestartGameObject;
    public GameObject startQuizObject;
    public GameObject menuButtonQuizObject;
    public GameObject feedbackPopup; // Pop-up untuk feedback
    public GameObject correctAnswerPopUp;
    public GameObject wrongAnswerPopUp;
    private int currentPartList = 0;
    public Text feedbackText; // Text untuk menampilkan feedback
    public Text correctAnswerText; // Text untuk menampilkan jawaban yang benar
    public Text feedbackQuestionText;
    public GameObject planetTampil;

    [System.Serializable]
    public class PlanetMateri
    {
        public string materi;
        public Sprite planetSprite;
    }
    public List<PlanetMateri> planetMateri;
    public Image planetImage;
    public Text materiText;
    private int currentPlanetIndex = 0;

    [System.Serializable]
    public class FaktaMenarik
    {
        public string fakta;
    }
    public List<FaktaMenarik> faktaMenarik;
    public Text faktaText;
    private int currentFaktaIndex = 0;

    
    [System.Serializable]
    public class QuizQuestion
    {
        public string question;
        public string[] options;
        public int correctAnswerIndex;
    }

    public List<QuizQuestion> quizQuestions;
    public Text questionNumberText; // GameObject untuk menampilkan nomor soal

    public Text questionText;
    public Button[] answerButtons;
    private int score = 0;
    private int currentQuestionIndex = 0;

    void Start()
    {
        ShuffleQuestions(); // Mengacak soal saat mulai
        DisplayQuestion();
    }
    void Update() {
        NextBackMateri();
    }

    void DisplayMateri() {
        planetTampil.SetActive(true);
        PlanetMateri currentMateri = planetMateri[currentPlanetIndex];
        materiText.text = currentMateri.materi;
        planetImage.sprite = currentMateri.planetSprite;
    }
    void DisplayFakta(){
        planetTampil.SetActive(false);
        FaktaMenarik currentFakta = faktaMenarik[currentFaktaIndex];
        faktaText.text = currentFakta.fakta;
    }

    void NextBackMateri() {
        if (currentPartList == 0) {
            listPart1GameObject.SetActive(true);
            listPart2GameObject.SetActive(false);
            listPart3GameObject.SetActive(false);
            listBack.SetActive(false);
            listNext.SetActive(true);
        } if (currentPartList == 1) {
            listPart1GameObject.SetActive(false);
            listPart2GameObject.SetActive(true);
            listPart3GameObject.SetActive(false);
            listBack.SetActive(true);
            listNext.SetActive(true);
        } if (currentPartList == 2) {
            listPart1GameObject.SetActive(false);
            listPart2GameObject.SetActive(false);
            listPart3GameObject.SetActive(true);
            listBack.SetActive(true);
            listNext.SetActive(false);
        }
    }
    public void NextMateri() {
        if (currentPartList <= 2) {
        currentPartList += 1;
        }
    }
    public void BackMateri() {
        if (currentPartList >= 0) {
        currentPartList -= 1;
        }
    }

    public void SwitchSceneSimulation() {
        SceneManager.LoadScene(SceneSimulation);
    }

    void ShuffleQuestions()
    {
        for (int i = 0; i < quizQuestions.Count; i++)
        {
            QuizQuestion temp = quizQuestions[i];
            int randomIndex = Random.Range(i, quizQuestions.Count);
            quizQuestions[i] = quizQuestions[randomIndex];
            quizQuestions[randomIndex] = temp;
        }
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < quizQuestions.Count && currentQuestionIndex < 30) // Hanya tampilkan hingga 30 soal
        {
            QuizQuestion currentQuestion = quizQuestions[currentQuestionIndex];
            questionText.text = currentQuestion.question;
            questionNumberText.text = "Soal " + (currentQuestionIndex + 1) + " dari 30"; // Menampilkan nomor soal

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.options[i];
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
        string selectedAnswer = quizQuestions[currentQuestionIndex].options[index]; // Menyimpan jawaban yang dipilih
        string correctAnswer = quizQuestions[currentQuestionIndex].options[quizQuestions[currentQuestionIndex].correctAnswerIndex];

        if (index == quizQuestions[currentQuestionIndex].correctAnswerIndex)
        {
            feedbackQuestionText.text = questionText.text;
            score++;
            correctAnswerPopUp.SetActive(true);
            wrongAnswerPopUp.SetActive(false);
            ShowFeedback("Jawabanmu Benar", "Dengan Jawaban " + correctAnswer + "  Tepat Sekali"); // Tampilkan pop-up dengan pesan benar
        
        }
        else
        {
            feedbackQuestionText.text = questionText.text;
            correctAnswerPopUp.SetActive(false);
            wrongAnswerPopUp.SetActive(true);
            ShowFeedback("Jawabanmu Salah", "Dengan Jawaban " + selectedAnswer + "  Salah!!! " + "  Jawaban yang benar: " + correctAnswer); // Tampilkan pop-up dengan jawaban yang benar
        
        }
    currentQuestionIndex++;
     // Tunda untuk menampilkan pertanyaan berikutnya
    }
    void ShowFeedback(string message, string correctAnswer)
    {
    feedbackText.text = message;
    if (correctAnswer != null)
    {
        correctAnswerText.text = correctAnswer;
    }
    feedbackPopup.SetActive(true); // Tampilkan pop-up
    quizStartGameObject.SetActive(false);
    }
    public void CloseFeedbackPopup()
    {
    feedbackPopup.SetActive(false); // Sembunyikan pop-up
    DisplayQuestion();
    quizStartGameObject.SetActive(true);
    }
    

    void EndQuiz()
    {
        questionText.text = "Quiz Berakhir! Nilaimu Adalah: " + (score * 100 / 30);
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
            quizRestartGameObject.SetActive(true);
            menuButtonQuizObject.SetActive(true);
        }
    }

    public void MateriList() {
        splashGameObject.SetActive(false);
        materiListGameObject.SetActive(true);
        materiTampilGameObject.SetActive(false);
        quizGameObject.SetActive(false);
        puzzleGameObject.SetActive(false);
        menuGameObject.SetActive(false);
    }
    public void MateriTampil() {
        splashGameObject.SetActive(false);
        materiListGameObject.SetActive(false);
        materiTampilGameObject.SetActive(true);
        quizGameObject.SetActive(false);
        puzzleGameObject.SetActive(false);
        menuGameObject.SetActive(false);
    }
    public void FaktaTampil() {
        splashGameObject.SetActive(false);
        materiListGameObject.SetActive(false);
        materiTampilGameObject.SetActive(true);
        quizGameObject.SetActive(false);
        puzzleGameObject.SetActive(false);
        menuGameObject.SetActive(false);
    }
    public void FaktaMenarikButtonClick(){
        currentFaktaIndex = 0;
        DisplayFakta();
    }
    public void FaktaNext(){
        if (currentFaktaIndex < faktaMenarik.Count - 1) {
            currentFaktaIndex++;
            DisplayFakta();
        }
    }
    public void FaktaPrevious(){
        if (currentFaktaIndex > 0) {
            currentFaktaIndex--;
            DisplayFakta();
        }
    }
    public void MatahariButtonClick() {
        currentPlanetIndex = 0;
        DisplayMateri();
        MateriTampil();
    }
    public void MerkuriusButtonClick() {
        currentPlanetIndex = 1;
        DisplayMateri();
        MateriTampil();
    }
    public void VenusButtonClick() {
        currentPlanetIndex = 2;
        DisplayMateri();
        MateriTampil();
    }
    public void BumiButtonClick() {
        currentPlanetIndex = 3;
        DisplayMateri();
        MateriTampil();
    }
    public void MarsButtonClick() {
        currentPlanetIndex = 4;
        DisplayMateri();
        MateriTampil();
    }
    public void JupiterButtonClick() {
        currentPlanetIndex = 5;
        DisplayMateri();
        MateriTampil();
    }
    public void SaturnusButtonClick() {
        currentPlanetIndex = 6;
        DisplayMateri();
        MateriTampil();
    }
    public void UranusButtonClick() {
        currentPlanetIndex = 7;
        DisplayMateri();
        MateriTampil();
    }
    public void NeptunusButtonClick() {
        currentPlanetIndex = 8;
        DisplayMateri();
        MateriTampil();
    }
    public void QuizButtonClick() {
        materiListGameObject.SetActive(false);
        materiTampilGameObject.SetActive(false);
        quizGameObject.SetActive(true);
        puzzleGameObject.SetActive(false);
        menuGameObject.SetActive(false);
        quizStartGameObject.SetActive(false);
        startQuizObject.SetActive(true);
        quizRestartGameObject.SetActive(false);
    }
    public void PuzzleButtonClick() {
        materiListGameObject.SetActive(false);
        materiTampilGameObject.SetActive(false);
        quizGameObject.SetActive(false);
        puzzleGameObject.SetActive(true);
        menuGameObject.SetActive(false);
    }
    public void MenuBackClick() {
        splashGameObject.SetActive(false);
        materiListGameObject.SetActive(false);
        materiTampilGameObject.SetActive(false);
        quizGameObject.SetActive(false);
        puzzleGameObject.SetActive(false);
        menuGameObject.SetActive(true);
    }
    public void QuizStarted() {
        quizStartGameObject.SetActive(true);
        startQuizObject.SetActive(false);
        quizRestartGameObject.SetActive(false);
        menuButtonQuizObject.SetActive(false);
        RestartQuiz();
    }
    public void MenuBackfromQuiz() {
        splashGameObject.SetActive(false);
        quizStartGameObject.SetActive(false);
        startQuizObject.SetActive(false);
        menuButtonQuizObject.SetActive(false);
        menuGameObject.SetActive(true);
    }
    public void RestartQuiz() // New method to restart the quiz
    {
        score = 0;
        currentQuestionIndex = 0;
        DisplayQuestion(); // Display the first question again
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(true); // Show answer buttons
        }
    }
    
}
