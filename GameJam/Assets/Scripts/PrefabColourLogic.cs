using UnityEngine;

public class PrefabColourLogic : MonoBehaviour
{
    [SerializeField] MeshRenderer MyMesh;
    [SerializeField] BoxCollider MyCollider;
    [SerializeField] ScriptableBool MyBool;

    private Material mat;
    private float speed = 2f;



    void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }

   /* private void FixedUpdate()
    {
        if (MyBool.Value)
        {
            SetObjOpaq();
        }
        else if (!MyBool.Value)
        {
            SetObjTrans();
        }
    }*/

    public void UpdateColour()
    {
        if (MyBool.Value)
        {
            SetObjOpaq();
        }
        else if (!MyBool.Value)
        {
            SetObjTrans();
        }
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
        else 
        {
            MyCollider.enabled = false;
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
            MyCollider.enabled = true;
        }
    }
}