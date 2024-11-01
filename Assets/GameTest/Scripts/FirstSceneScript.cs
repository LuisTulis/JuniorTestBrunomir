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

        dialogTexts.Add(new DialogData("/emote:Happy/¡Vamos a ver tus habilidades /color:red/matemáticas/color:white/!/emote:Normal/", "Li"));

        var text1 = new DialogData("¿Sobre qué quieres que te pregunte?");
        text1.SelectList.Add("Facil", "Adición y sustracción.");
        text1.SelectList.Add("Medio", "Multiplicación y división.");
        text1.SelectList.Add("Dificil", "Potenciación y radicación.");

        text1.Callback = () => answerQuestion();
        
        dialogTexts.Add(text1);

        var text2 = new DialogData("/emote:Happy/¡Vamos con las preguntas!/emote:Normal/", "Li");
        text2.Callback = () => SceneManager.LoadScene(1);
        dialogTexts.Add(text2);

        DialogManager.Show(dialogTexts);
    }

    /// <summary>
    /// Basado en la respuesta del usuario, se agregará a la línea de diálogo un mensaje u otro. 
    /// </summary>
    private void answerQuestion()
    {
        var answerText = "/emote:Sad/No te criticaré si fallas. . .";
        PlayerAnswers answerManager = FindObjectOfType<PlayerAnswers>();
        answerManager.testMode = 2;

        if (DialogManager.Result == "Facil")
        {
            answerText = "/emote:Happy/¡Oh, seguro te irá bien!";
            answerManager.testMode = 0;

        }
        else if (DialogManager.Result == "Medio")
        {
            answerText = "/emote:Normal/¡Seguro será complicado!";
            answerManager.testMode = 1;
        }
        
        var dialogTexts = new List<DialogData>();

        var text2 = new DialogData(answerText, "Li");

        dialogTexts.Add(text2);

        DialogManager.Show(dialogTexts);

    }
}
