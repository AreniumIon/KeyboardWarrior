using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Saving should happen automatically, but for now I am testing with a button

public class SaveButton : MonoBehaviour
{
    public void Click()
    {
        SaveController.Save();
    }
}
