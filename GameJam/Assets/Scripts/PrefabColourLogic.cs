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
        if (inRangeOfPlayer)
        {
            if (MyBool.Value)
                SetObjAct();
        }

        if (!MyBool.Value)
        {
            SetObjUnAct();
            inRangeOfPlayer = false;
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