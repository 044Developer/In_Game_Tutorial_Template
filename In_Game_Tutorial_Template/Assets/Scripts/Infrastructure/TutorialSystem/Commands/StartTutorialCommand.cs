using TutorialProject.Infrastructure.TutorialSystem.Controller;
using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using TutorialProject.UI.TutorialPanel.Model;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class StartTutorialCommand : ITutorialCommand
    {
        private readonly TutorialDataModel m_tutorialDataModel;
        private readonly TutorialPanelModel m_tutorialPanelModel;
        private readonly TutorialSystemController m_tutorialSystemController;

        public StartTutorialCommand(TutorialDataModel tutorialDataModel, TutorialPanelModel tutorialPanelModel, TutorialSystemController tutorialSystemController)
        {
            m_tutorialDataModel = tutorialDataModel;
            m_tutorialPanelModel = tutorialPanelModel;
            m_tutorialSystemController = tutorialSystemController;
            
            InitializeTutorial();
        }
        
        public void Execute()
        {
            InitializePanelView();
        }

        private void InitializeTutorial()
        {
            m_tutorialSystemController.TutorialModel.IsTutorialActive = true;
            m_tutorialSystemController.TutorialModel.CurrentTutorialID = m_tutorialDataModel.TutorialID;
            m_tutorialSystemController.TutorialModel.CurrentStepIndex = 0;
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