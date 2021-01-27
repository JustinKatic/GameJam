using UnityEngine;

public class PrefabColourLogic : MonoBehaviour
{
    [SerializeField] MeshRenderer MyMesh;
    [SerializeField] BoxCollider MyCollider;
    [SerializeField] ScriptableBool MyBool;


    void Start()
    {
    }

    private void Update()
    {
        if (MyBool.Value)
        {
            SetObjAct();
        }
        else if (!MyBool.Value)
        {
            SetObjUnAct();
        }
    }


    void SetObjAct()
    {
        MyCollider.enabled = true;
        MyMesh.enabled = true;
    }

    void SetObjUnAct()
    {
        MyCollider.enabled = false;
        MyMesh.enabled = false;
    }
}