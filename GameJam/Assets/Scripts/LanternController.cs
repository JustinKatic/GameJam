using UnityEngine;

public class LanternController : MonoBehaviour
{
    [SerializeField] KeyCode FirstKey, SecondKey, ResetKey;
    [SerializeField] ScriptableBool[] Colours;
    [SerializeField] GameEvent RedLightActive;
    [SerializeField] GameEvent GreenLightActive;
    [SerializeField] GameEvent BlueLightActive;


    int currentColour;

    private void OnEnable() => currentColour = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(FirstKey))
        {
            currentColour--;
            if (currentColour < 0)
                currentColour = Colours.Length - 1;
            UpdateBoolean();
        }
        if (Input.GetKeyUp(SecondKey))
        {
            currentColour++;
            if (currentColour > Colours.Length - 1)
                currentColour = 0;
            UpdateBoolean();
        }
        if(Input.GetKeyUp(ResetKey))
        {
            currentColour = Colours.Length + 1;
            UpdateBoolean();
            currentColour = 0;
        }
    }

    void UpdateBoolean()
    {
        foreach (ScriptableBool sb in Colours)
            sb.Value = false;
        if(currentColour < Colours.Length)
            Colours[currentColour].Value = true;

        if (currentColour == 2)
        {
            Debug.Log("Green");
            GreenLightActive.Raise();
        }
        else if (currentColour == 1)
        {
            Debug.Log("Blue");
            BlueLightActive.Raise();

        }
        else if (currentColour == 0)
        {
            Debug.Log("Red");
            RedLightActive.Raise();

        }
    }
}
