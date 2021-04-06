using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mactinite.ExtensibleDamageSystem.Numbers
{
    public class DamageDisplayManager : SingletonMonobehavior<DamageDisplayManager>
    {

        public Transform textPrefab;
        public Transform parent;
        public int preload = 25;

        private List<Transform> damageNumbers = new List<Transform>();
        private List<Transform> sleepingText = new List<Transform>();
        private void Awake()
        {
            for (int i = 0; i < preload; i++)
            {
                var text = Instantiate(textPrefab);
                text.transform.position = Vector2.zero;
                text.transform.SetParent(parent);
                text.gameObject.SetActive(false);
                damageNumbers.Add(text.transform);
            }
        }

        private void FixedUpdate()
        {
            GetSleepingText();
        }

        public void GetSleepingText()
        {
            foreach (var obj in damageNumbers)
            {
                if (!obj.gameObject.activeSelf)
                {
                    sleepingText.Add(obj);
                }
            }
        }

        public static void SpawnText(string text, Color textColor, Vector3 spawnOn)
        {
            DamageDisplayManager.Instance.InstantiateText(text, textColor, spawnOn);
        }

        public void InstantiateText(string text, Color textColor, Vector3 spawnOn)
        {
            Transform dmgText = null;
            if (sleepingText.Count > 0)
            {
                dmgText = sleepingText[0];
                sleepingText.RemoveAt(0);
            }
            else
            {
                dmgText = Instantiate(textPrefab);
                damageNumbers.Add(dmgText);
            }

            if (dmgText != null)
            {
                dmgText.position = Vector3.zero;
                dmgText.SetParent(parent, false);
                DamageDisplay dmgDisplay = dmgText.GetComponent<DamageDisplay>();
                dmgDisplay.riseFrom = spawnOn;
                dmgDisplay.Init();
                dmgDisplay.SetText(text, textColor);
                dmgDisplay.started = true;
                damageNumbers.Add(dmgText);
                dmgText.gameObject.SetActive(true);

            }

        }
    }
}
