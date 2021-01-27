using UnityEngine;

public class PrefabColourLogic : MonoBehaviour
{
    [SerializeField] MeshRenderer MyMesh;
    [SerializeField] BoxCollider MyCollider;
    [SerializeField] ScriptableBool MyBool;

    private Material mat;
    public float speed;

    private void OnEnable() => SetMesh(false);

    void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void FixedUpdate()
    {
        if (MyBool.Value && !MyMesh.enabled)
        {
            //SetObjOpaq();
            SetMesh(true);
        }
        else if (!MyBool.Value && MyMesh.enabled)
        {
            SetMesh(false);
            //SetObjTrans();
        }
    }
    void SetMesh(bool b)
    {
        MyMesh.enabled = b;
        MyCollider.enabled = b;
    }


    void SetObjTrans()
    {
        if (mat.color.a > 0)
        {
            Color newColor = mat.color;
            newColor.a -= Time.deltaTime * speed;
            mat.color = newColor;
            gameObject.GetComponent<MeshRenderer>().material = mat;
        }
    }

    void SetObjOpaq()
    {
        if (mat.color.a < 255)
        {
            Color newColor = mat.color;
            newColor.a += Time.deltaTime * speed;
            mat.color = newColor;
            gameObject.GetComponent<MeshRenderer>().material = mat;
        }
    }
}