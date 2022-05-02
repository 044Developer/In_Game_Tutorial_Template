using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using TutorialProject.UI.TutorialPanel.Model;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class StartTutorialCommand : ITutorialCommand
    {
        private readonly TutorialDataModel m_tutorialDataModel;
        private readonly TutorialPanelModel m_tutorialPanelModel;
        private readonly TutorialSystemModel m_tutorialSystemModel;

        public StartTutorialCommand(TutorialDataModel tutorialDataModel, TutorialPanelModel tutorialPanelModel, TutorialSystemModel tutorialSystemModel)
        {
            m_tutorialDataModel = tutorialDataModel;
            m_tutorialPanelModel = tutorialPanelModel;
            m_tutorialSystemModel = tutorialSystemModel;
            
            InitializeTutorial();
        }
        
        public void Execute()
        {
            InitializePanelView();
        }

        private void InitializeTutorial()
        {
            m_tutorialSystemModel.IsTutorialActive = true;
            m_tutorialSystemModel.CurrentTutorialID = m_tutorialDataModel.TutorialID;
        }

        private void InitializePanelView()
        {
            m_tutorialPanelModel.ExecuteStepButton.gameObject.SetActive(true);
        }

        public void Exit()
        {
        }
    }
}