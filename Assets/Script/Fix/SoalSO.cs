using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoalSO", menuName = "SoalSO")]
public class SoalSO : ScriptableObject
{
    [TextArea(2, 5)]
    public string questionText;
    public List<string> answers;
    // Index of the correct answer in the answers list
    public int correctAnswerIndex;

    
}
