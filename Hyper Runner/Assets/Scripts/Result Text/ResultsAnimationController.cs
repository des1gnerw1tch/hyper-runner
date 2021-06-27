using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsAnimationController : MonoBehaviour {
    [SerializeField] private AResultText first;

    private void Start() {
        this.first.Activate();
    }
}
