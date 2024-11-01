using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class ThirdSceneScript : MonoBehaviour
{
    public DialogManager DialogManager;
    PlayerAnswers answerManager;

    private void Awake()
    {
        answerManager = FindObjectOfType<PlayerAnswers>();

        string firstText = "";
        string secondText = "";

        switch (answerManager.testMode)
        {
            case 0:
                firstText = "Adición y sustracción, son sencillas, pero si te distraés, podés llegar a confundirte.";
                break;
            case 1:
                firstText = "Multiplicación y división, si seguís los pasos correctamente, no vas a fallar a no ser que intentes adivinar.";
                break;
            case 2:
                firstText = "Potenciación y radicación, difícil la tiene el que no conoce sus propiedades.";
                break;
        }

        switch (answerManager.answer)
        {
            case 0:
                secondText = "/emote:Normal/Aun así, un error lo comete cualquiera, ¡no te preocupes por ello!";
                break;
            case 1:
                secondText = "/emote:Happy/¡Y parece que tú las dominas! ¡Te felicito!";
                break;
            case 2:
                secondText = "/emote:Sad/Y ese fue tu caso. . . Hay que esforzarse para fallar de esa manera. . .";
                break;
        }

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData(firstText, "Li"));

        dialogTexts.Add(new DialogData(secondText, "Li"));
        
        DialogManager.Show(dialogTexts);
    }
}
