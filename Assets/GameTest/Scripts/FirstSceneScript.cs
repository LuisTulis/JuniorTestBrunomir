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

        dialogTexts.Add(new DialogData("/emote:Happy/�Vamos a ver tus habilidades /color:red/matematicas/color:white/!/emote:Normal/", "Li"));

        var Text1 = new DialogData("�Sobre que quieres que te pregunte?");
        Text1.SelectList.Add("Facil", "Adici�n y sustracci�n.");
        Text1.SelectList.Add("Medio", "Multiplicaci�n y divisi�n.");
        Text1.SelectList.Add("Dificil", "Potenciaci�n y radicaci�n.");

        Text1.Callback = () => answerQuestion();
        
        dialogTexts.Add(Text1);

        var Text2 = new DialogData("/emote:Happy/�Vamos con las preguntas!/emote:Normal/", "Li");
        Text2.Callback = () => SceneManager.LoadScene(1);
        dialogTexts.Add(Text2);

        DialogManager.Show(dialogTexts);
       
    }

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
