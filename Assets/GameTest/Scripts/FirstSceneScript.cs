using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using Mono.Cecil;

public class FirstSceneScript : MonoBehaviour
{
    public DialogManager DialogManager;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hola, bienvenido a esta /size:up/prueba./size:init/", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/�Vamos a ver tus habilidades /color:red/matem�ticas/color:white/!/emote:Normal/", "Li"));

        var text1 = new DialogData("�Sobre qu� quieres que te pregunte?");
        text1.SelectList.Add("Facil", "Adici�n y sustracci�n.");
        text1.SelectList.Add("Medio", "Multiplicaci�n y divisi�n.");
        text1.SelectList.Add("Dificil", "Potenciaci�n y radicaci�n.");

        text1.Callback = () => answerQuestion();
        
        dialogTexts.Add(text1);

        var text2 = new DialogData("/emote:Happy/�Vamos con las preguntas!/emote:Normal/", "Li");
        text2.Callback = () => SceneManager.LoadScene(1);
        dialogTexts.Add(text2);

        DialogManager.Show(dialogTexts);
    }

    /// <summary>
    /// Basado en la respuesta del usuario, se agregar� a la l�nea de di�logo un mensaje u otro. 
    /// </summary>
    private void answerQuestion()
    {
        var answerText = "/emote:Sad/No te criticar� si fallas. . .";
        PlayerAnswers answerManager = FindObjectOfType<PlayerAnswers>();
        answerManager.testMode = 2;

        if (DialogManager.Result == "Facil")
        {
            answerText = "/emote:Happy/�Oh, seguro te ir� bien!";
            answerManager.testMode = 0;

        }
        else if (DialogManager.Result == "Medio")
        {
            answerText = "/emote:Normal/�Seguro ser� complicado!";
            answerManager.testMode = 1;
        }
        
        var dialogTexts = new List<DialogData>();

        var text2 = new DialogData(answerText, "Li");

        dialogTexts.Add(text2);

        DialogManager.Show(dialogTexts);

    }
}
