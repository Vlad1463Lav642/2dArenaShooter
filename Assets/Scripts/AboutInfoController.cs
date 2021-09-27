using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutInfoController : MonoBehaviour
{
    [SerializeField] private Text nameLabel;
    [SerializeField] private Text healthLabel;
    [SerializeField] private Text forceLabel;
    [SerializeField] private Text damageLabel;

    public void ChooseCharacter(string name, int health, float force, int damage)
    {
        nameLabel.text = name;
        healthLabel.text = $": {health}";
        forceLabel.text = $": {force}";
        damageLabel.text = $": {damage}";
    }
}