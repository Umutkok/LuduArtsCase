using UnityEngine;
using TMPro;
using UnityEngine.UI;
using InteractionSystem.Core;

namespace InteractionSystem.UI
{
    public sealed class InteractionUIController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TMP_Text m_PromptText;
        [SerializeField] private TMP_Text m_FeedbackText;
        [SerializeField] private Image m_HoldProgressBar;
        [SerializeField] private Image m_RedKeyImage;
        [SerializeField] private Image m_BlueKeyImage;

        #endregion

        #region Private Fields
        private PlayerInventory m_Inventory;
        #endregion

        #region Unity Methods

        private void Awake()
        {
            ClearUI();

            m_Inventory = FindAnyObjectByType<PlayerInventory>();

            if (m_Inventory != null)
            {
                m_Inventory.KeyAdded += ShowKeyIcon;
            }
        }

        #endregion

        #region Public API

        public void ShowPrompt(string text)
        {
            m_PromptText.text = text;
            m_PromptText.gameObject.SetActive(true);
        }

        public void HidePrompt()
        {
            m_PromptText.gameObject.SetActive(false);
        }

        public void UpdateHoldProgress(float progress)
        {
            if (m_HoldProgressBar == null) return;

            m_HoldProgressBar.fillAmount = progress;
            m_HoldProgressBar.gameObject.SetActive(progress > 0f);
            Debug.Log("sadsa0");
        }

        public void ShowFeedback(string message)
        {
            m_FeedbackText.text = message;
            m_FeedbackText.gameObject.SetActive(true);
        }

        public void HideFeedback()
        {
            m_FeedbackText.gameObject.SetActive(false);
        }

        public void ClearUI()
        {
            HidePrompt();
            HideFeedback();

            if (m_HoldProgressBar != null)
                m_HoldProgressBar.gameObject.SetActive(false);
        }

        /// <summary>
        /// key ikonu id ye göre gösterilir.
        /// </summary>
        public void ShowKeyIcon(ItemData key)
        {
            if (key == null) return;

            switch (key.ItemId)
            {
                case "Key_Red":
                    m_RedKeyImage.gameObject.SetActive(true);
                    break;

                case "Key_Blue":
                    m_BlueKeyImage.gameObject.SetActive(true);
                    break;
            }
        }

        #endregion
    }
}
