using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SecondSceneScript : MonoBehaviour
{

    public DialogManager DialogManager;
    PlayerAnswers answerManager;
    private void Awake()
    {
        answerManager = FindObjectOfType<PlayerAnswers>();

        var dialogTexts = new List<DialogData>();

        string answerText = "";
        string answerA = "";
        string answerB = "";
        string answerC = "";

        switch (answerManager.testMode)
        {
            case 0:
                answerText = "¡Bien! ¿Cuánto es 5 + 10 - 7?";
                answerA = "9";
                answerB = "8";
                answerC = "28";
                break;
            case 1:
                answerText = "¡Bien! ¿Cuánto es 7 * 8 dividido 4?";
                answerA = "16";
                answerB = "14";
                answerC = "450";
                break;
            case 2:
                answerText = "¡Bien! ¿Cuánto es la raíz cuadrada de 5^4?";
                answerA = "5";
                answerB = "25";
                answerC = "390625";
                break;
        }

        DialogData text1 = new DialogData(answerText, "Li");

        text1.SelectList.Add("OpcionA", answerA);
        text1.SelectList.Add("OpcionB", answerB);
        text1.SelectList.Add("OpcionC", answerC);
        
        text1.Callback = () => answerQuestion();

        dialogTexts.Add(text1);

        DialogData text2 = new DialogData("No se me ocurre que texto poner acá.", "Sa");
        
        text2.Callback = () => SceneManager.LoadScene(2);


        dialogTexts.Add(text2);

        DialogManager.Show(dialogTexts);
    }

    /// <summary>
    /// Basado en la respuesta del usuario, se agregará a la línea de diálogo un mensaje u otro. 
    /// </summary>
    private void answerQuestion()
    {
        var answerText = "/emote:Sad/¿Como siquiera llegaste a ese resultado?";
        answerManager.answer = 2;

        if (DialogManager.Result == "OpcionA")
        {
            answerText = "/emote:Normal/¡Incorrecto! Pero bueno, aunque sea lo intentaste. . .";
            answerManager.answer = 0;
        }
        else if (DialogManager.Result == "OpcionB")
        {
            answerText = "/emote:Happy/¡Correcto!";
            answerManager.answer = 1;
        }

        var dialogTexts = new List<DialogData>();

        var text2 = new DialogData(answerText, "Li");

        dialogTexts.Add(text2);

        DialogManager.Show(dialogTexts);

    }
}
