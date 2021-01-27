using UnityEngine;
using UnityEngine.UI;
public class CurrentColourLogic : MonoBehaviour
{
    [SerializeField] ScriptableBool[] Colours;
    [SerializeField] Text myText;
    [SerializeField] Image myImage, QImage, EImage;

    int currentColour;
    private void OnEnable()
    {
        currentColour = 0;
        UpdateText(currentColour);
    }
    private void FixedUpdate()
    {
        bool found = false;
        for (int i = 1; i < Colours.Length && !found; i++)
        {
            if (Colours[i].Value)
            {
                found = true;
                currentColour = i;
            }
        }
        if (!found)
            currentColour = 0;
        UpdateText(currentColour);
    }

    void UpdateText(int i)
    {
        switch (i)
        {
            case 1:
                myText.text = "Red";
                QImage.color = Color.green;
                myImage.color = Color.red;
                EImage.color = Color.blue;
                break;
            case 2:
                myText.text = "Green";
                QImage.color = Color.blue;
                myImage.color = Color.green;
                EImage.color = Color.red;
                break;
            case 3:
                myText.text = "Blue";
                QImage.color = Color.red;
                myImage.color = Color.blue;
                EImage.color = Color.green;
                break;
            default:
                myText.text = "None";
                QImage.color = Color.green;
                myImage.color = Color.white;
                EImage.color = Color.blue;
                break;
        }
    }
}
