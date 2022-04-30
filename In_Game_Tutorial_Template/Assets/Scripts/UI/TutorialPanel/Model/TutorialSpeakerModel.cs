using System;
using TMPro;
using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialProject.UI.TutorialPanel.Model
{
    [Serializable]
    public class TutorialSpeakerModel
    {
        [SerializeField] private TutorialTextPosition m_tutorialTextPosition = TutorialTextPosition.None;
        [SerializeField] private GameObject m_speakerHolderObject = null;
        [SerializeField] private Image m_speakerAvatarImage = null;
        [SerializeField] private TextMeshProUGUI m_speakerText = null;

        public TutorialTextPosition TutorialTextPosition => m_tutorialTextPosition;
        public GameObject SpeakerHolderObject => m_speakerHolderObject;
        public Image SpeakerAvatarImage => m_speakerAvatarImage;
        public TextMeshProUGUI SpeakerText => m_speakerText;
    }
}