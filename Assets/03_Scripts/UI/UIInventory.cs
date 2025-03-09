using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject back;
     
    public void OnOffInventory(bool _active)
    {
        back.SetActive(_active);

	}
}
