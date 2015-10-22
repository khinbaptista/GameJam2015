using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTyperScript : MonoBehaviour
{

    public bool endText = false;
    public GameObject speech;
    public float letterPause = 0.2f;

    string message;
    Text textComp;

    // Use this for initialization

    void OnEnable()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
            StartCoroutine(TypeText());
        
    }

    void Update()
    {
       
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        endText = true;
    }
}