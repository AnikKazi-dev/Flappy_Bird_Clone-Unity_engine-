using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyAnim : MonoBehaviour
{
    public GameObject afterTapBut;

    public void AfterGetReadyAnimationEnds()
    {
        afterTapBut.SetActive(false);
    }
    // Start is called before the first frame update

}
