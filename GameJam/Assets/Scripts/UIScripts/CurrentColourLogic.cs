using UnityEngine;
using UnityEngine.UI;
public class CurrentColourLogic : MonoBehaviour
{
    [SerializeField] ScriptableBool[] Colours;
    [SerializeField] Text myText;
    [SerializeField] Image myImage;

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
                myImage.color = Color.red;
                break;
            case 2:
                myText.text = "Green";
                myImage.color = Color.green;
                break;
            case 3:
                myText.text = "Blue";
                myImage.color = Color.blue;
                break;
            default:
                myText.text = "None";
                myImage.color = Color.white;
                break;
        }
    }
}
