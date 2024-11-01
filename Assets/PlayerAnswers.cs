using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswers : MonoBehaviour
{
    public int testMode;
    public int answer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
