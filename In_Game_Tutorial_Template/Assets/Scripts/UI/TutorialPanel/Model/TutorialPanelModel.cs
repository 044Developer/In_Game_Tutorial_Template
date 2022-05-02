using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialProject.UI.TutorialPanel.Model
{
    [Serializable]
    public class TutorialPanelModel
    {
        [Header("Main Panel Components")]
        [SerializeField] private Image m_fadeImage = null;
        [SerializeField] private Button m_executeStepButton = null;
        [SerializeField] private List<GameObject> m_tutorialArrowsList = null;
        [SerializeField] private List<Sprite> m_speakerAvatars = null;

        [Header("Speakers")] 
        [SerializeField] private List<TutorialSpeakerModel> m_speakerModels = null;

        public Image FadeImage => m_fadeImage;
        public Button ExecuteStepButton => m_executeStepButton;
        public List<GameObject> TutorialArrowsList => m_tutorialArrowsList;
        public List<Sprite> SpeakerAvatars => m_speakerAvatars;
        public List<TutorialSpeakerModel> SpeakerModels => m_speakerModels;
    }
}