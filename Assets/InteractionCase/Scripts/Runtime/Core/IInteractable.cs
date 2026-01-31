using UnityEngine;

namespace InteractionSystem.Core
{
    /// <summary>
    /// Player tarafından etkileşime girilebilir objeler
    /// </summary>

    public interface IInteractable
    {
        /// <summary>
        /// anında çağırılan interaction
        /// tek tıklama ile aktifleşir
        /// </summary>
        InteractionType InteractionType { get; }

        float HoldDuration { get; }
        void InteractInstant();

        /// <summary>
        /// Eğer basılı tutulursa sürekli olarak çağırılır
        /// </summary>
        /// <param name="holdProgress">
        /// Normalize etmek için bu sayede progress bar da kullanabiliriz.
        /// </param>
        void InteractHold(float holdProgress);

        /// <summary>
        /// true false için iki state i var
        /// </summary>
        void InteractToggle();
    }
}
