using UnityEngine;

public class PrefabColourLogic : MonoBehaviour
{
    [SerializeField] MeshRenderer MyMesh;
    [SerializeField] BoxCollider MyCollider;
    [SerializeField] ScriptableBool MyBool;

    public bool inRangeOfPlayer;


    void Start()
    {
    }

    private void Update()
    {
        if (inRangeOfPlayer && MyBool.Value)
        {
            SetObjAct();
        }
        else if (!inRangeOfPlayer && !MyBool.Value)
        {
            SetObjUnAct();
        }
    }


    void SetObjAct()
    {
        MyCollider.isTrigger = false;
        MyMesh.enabled = true;
    }

    void SetObjUnAct()
    {
        MyCollider.isTrigger = true;
        MyMesh.enabled = false;
    }
}