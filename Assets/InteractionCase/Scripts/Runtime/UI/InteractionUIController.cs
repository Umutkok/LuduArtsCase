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

        #endregion

        #region Unity Methods

        private void Awake()
        {
            ClearUI();
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

        #endregion
    }
}
