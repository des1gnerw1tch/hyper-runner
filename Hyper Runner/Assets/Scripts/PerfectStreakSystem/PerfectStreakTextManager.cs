using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PerfectStreakTextManager : MonoBehaviour {
    [SerializeField] private ConsPerfectStreak current; // current perfect streak object

    public GameObject SpawnPerfectStreakText(int perfectInARow) {
        GameObject temp = this.current.gameObject;
        this.current = this.current.next;
        temp.gameObject.GetComponent<TextMeshProUGUI>().text = "x" + perfectInARow;
        temp.SetActive(true);
        return temp;
    }
}
