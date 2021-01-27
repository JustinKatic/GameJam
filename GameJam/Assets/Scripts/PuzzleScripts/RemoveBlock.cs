using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlock : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    [SerializeField] BoxCollider col;
    //public GameObject wall;
    [SerializeField] ScriptableBool triggerBool;

    private void FixedUpdate()
    {
        if (mesh.enabled && triggerBool.Value) //turning the wall off
        {
            mesh.enabled = false;
            col.enabled = false;
        }

        if (!mesh.enabled && !triggerBool.Value)
        {
            mesh.enabled = true;
            col.enabled = true;
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.GetComponent<PrefabColourLogic>() != null)
    //    {
    //        //mesh.enabled = false;
    //        //col.enabled = false;
    //        wall.SetActive(false);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<PrefabColourLogic>() != null)
    //    {
    //        //mesh.enabled = true;
    //        //col.enabled = true;
    //    }
    //}
}
