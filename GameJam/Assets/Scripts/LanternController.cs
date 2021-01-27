using UnityEngine;

public class LanternController : MonoBehaviour
{
    [SerializeField] KeyCode FirstKey, SecondKey, ResetKey;
    [SerializeField] ScriptableBool[] Colours;

    [SerializeField] GameObject RedLantern;
    [SerializeField] GameObject GreenLantern;
    [SerializeField] GameObject BlueLantern;
    [SerializeField] GameObject WhiteLantern;

    public float PlayerRadius;
    public LayerMask colourCubesLayer;




    int currentColour;

    private void OnEnable() => currentColour = 0;
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, PlayerRadius, colourCubesLayer);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].gameObject.GetComponent<PrefabColourLogic>().inRangeOfPlayer = true;
            i++;
        }

            if (Input.GetKeyUp(FirstKey))
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
        if (Input.GetKeyUp(ResetKey))
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
        if (currentColour < Colours.Length)
        {
            Colours[currentColour].Value = true;
            UpdateLanternColour();
        }
    }

    public void UpdateLanternColour()
    {
        if(Colours[0].Value == true)
        {
            RedLantern.SetActive(true);
            GreenLantern.SetActive(false);
            BlueLantern.SetActive(false);
            WhiteLantern.SetActive(false);
        }
        else if (Colours[1].Value == true)
        {
            RedLantern.SetActive(false);
            GreenLantern.SetActive(false);
            BlueLantern.SetActive(true);
            WhiteLantern.SetActive(false);
        }
        else if(Colours[2].Value == true)
        {
            RedLantern.SetActive(false);
            GreenLantern.SetActive(true);
            BlueLantern.SetActive(false);
            WhiteLantern.SetActive(false);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerRadius);
    }

}
