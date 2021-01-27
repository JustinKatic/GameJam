using UnityEngine;

public class LanternController : MonoBehaviour
{
    [SerializeField] KeyCode FirstKey, SecondKey, ResetKey;
    [SerializeField] ScriptableBool[] Colours;

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
        }
    }

    void UpdateBoolean()
    {
        foreach (ScriptableBool sb in Colours)
            sb.Value = false;
        if(currentColour < Colours.Length)
            Colours[currentColour].Value = true;
    }
}
