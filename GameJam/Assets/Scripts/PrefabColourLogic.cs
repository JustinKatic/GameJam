using UnityEngine;

public class PrefabColourLogic : MonoBehaviour
{
    [SerializeField] MeshRenderer MyMesh;
    [SerializeField] ScriptableBool MyBool;
    private void OnEnable() => SetMesh(false);
    private void FixedUpdate()
    {
        if (MyBool.Value && !MyMesh.enabled)
            SetMesh(true);
        else if (!MyBool.Value && MyMesh.enabled)
            SetMesh(false);
    }
    void SetMesh(bool b) => MyMesh.enabled = b;
}