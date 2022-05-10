using TutorialProject.Infrastructure.TutorialSystem.Controller;
using TutorialProject.Infrastructure.TutorialSystem.Data.HighlightedData;
using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using TutorialProject.UI.TutorialPanel.Model;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class NextStepTutorialCommand : ITutorialCommand
    {
        private readonly TutorialStepData m_tutorialStepData;
        private readonly TutorialPanelModel m_tutorialPanelModel;
        private readonly TutorialSystemController m_tutorialSystemController;
        private TutorialSpeakerModel m_currentSpeakerViewModel;

        public NextStepTutorialCommand(TutorialStepData tutorialStepData, TutorialPanelModel tutorialPanelModel, TutorialSystemController tutorialSystemModel)
        {
            m_tutorialStepData = tutorialStepData;
            m_tutorialPanelModel = tutorialPanelModel;
            m_tutorialSystemController = tutorialSystemModel;
            m_currentSpeakerViewModel = m_tutorialPanelModel.SpeakerModels.Find(it => it.TutorialTextPosition == m_tutorialStepData.TextPosition);

        }
        
        public void Execute()
        {
            SetTutorialView();
            InitializeStepView();
            InitializeStepIndex();
        }

        public void Exit()
        {
            UnHighlightElements();
            m_currentSpeakerViewModel.SpeakerAvatarImage.sprite = null;
            m_currentSpeakerViewModel.SpeakerText.text = string.Empty;
            m_currentSpeakerViewModel.SpeakerHolderObject.gameObject.SetActive(false);
        }

        private void SetTutorialView()
        {
            m_tutorialPanelModel.FadeImage.gameObject.SetActive(m_tutorialStepData.HasFadePanel);
            m_tutorialPanelModel.ExecuteStepButton.gameObject.SetActive(m_tutorialStepData.HasOkButton);
        }

        private void InitializeStepView()
        {
            m_currentSpeakerViewModel.SpeakerHolderObject.SetActive(true);
            m_currentSpeakerViewModel.SpeakerAvatarImage.sprite = m_tutorialPanelModel.SpeakerAvatars[m_tutorialStepData.SpeakerAvatarID];
            m_currentSpeakerViewModel.SpeakerText.text = m_tutorialStepData.DialogueTextKey;
        }

        private void InitializeStepIndex()
        {
            m_tutorialSystemController.TutorialModel.CurrentStepIndex = m_tutorialStepData.StepIndex;
        }

        private void UnHighlightElements()
        {
            if (m_tutorialSystemController.TutorialModel.HighlightedObjects.Count <= 0)
                return;

            foreach (IHighlightedTutorialElement tutorialElement in m_tutorialSystemController.TutorialModel.HighlightedObjects)
                tutorialElement.ReleaseElement();
        }
    }
}