using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using TutorialProject.UI.TutorialPanel.Model;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class NextStepTutorialCommand : ITutorialCommand
    {
        private readonly TutorialStepData m_tutorialStepData;
        private readonly TutorialPanelModel m_tutorialPanelModel;
        private TutorialSpeakerModel m_currentSpeakerViewModel;

        public NextStepTutorialCommand(TutorialStepData tutorialStepData, TutorialPanelModel tutorialPanelModel)
        {
            m_tutorialStepData = tutorialStepData;
            m_tutorialPanelModel = tutorialPanelModel;
            m_currentSpeakerViewModel = m_tutorialPanelModel.SpeakerModels.Find(it => it.TutorialTextPosition == m_tutorialStepData.TextPosition);

        }
        
        public void Execute()
        {
            SetTutorialView();
            InitializeStepView();
        }

        public void Exit()
        {
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
    }
}