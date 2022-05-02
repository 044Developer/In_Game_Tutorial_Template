using System.Collections.Generic;
using TutorialProject.Infrastructure.TutorialSystem.Commands;
using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using TutorialProject.Infrastructure.TutorialSystem.TutorialDataBase;
using TutorialProject.UI.TutorialPanel.Model;

namespace TutorialProject.Infrastructure.TutorialSystem.Controller
{
    public class TutorialSystemController
    {
        private ITutorialDataBase m_tutorialDataBase = null;
        private TutorialPanelModel m_tutorialPanelModel = null;
        private Queue<ITutorialCommand> m_tutorialCommandsQueue = null;
        private ITutorialCommand m_previousCommand = null;
        private TutorialSystemModel m_tutorialSystemModel = null;

        public TutorialSystemModel TutorialModel => m_tutorialSystemModel;

        public TutorialSystemController(ITutorialDataBase tutorialDataBase)
        {
            m_tutorialDataBase = tutorialDataBase;
            m_tutorialSystemModel = new TutorialSystemModel();
            m_tutorialCommandsQueue = new Queue<ITutorialCommand>();
        }

        public void Initialize(TutorialPanelModel tutorialPanelModel)
        {
            m_tutorialPanelModel = tutorialPanelModel;
            m_tutorialDataBase.Initialize();
        }

        public void StartTutorial(int tutorialID)
        {
            if (m_tutorialSystemModel.IsTutorialActive)
                return;
            
            m_tutorialCommandsQueue.Clear();
            
            TutorialDataModel currentTutorial = m_tutorialDataBase.GetTutorial(tutorialID);

            InitializeTutorial(currentTutorial);
        }

        public void ProceedWithNextTutorialStep()
        {
            if (!m_tutorialSystemModel.IsTutorialActive)
                return;
            
            m_previousCommand?.Exit();

            m_previousCommand = m_tutorialCommandsQueue.Dequeue();
            
            m_previousCommand.Execute();
        }

        private void InitializeTutorial(TutorialDataModel tutorialDataModel)
        {
            ITutorialCommand startTutorialCommand = new StartTutorialCommand(tutorialDataModel, m_tutorialPanelModel, m_tutorialSystemModel);
            m_tutorialCommandsQueue.Enqueue(startTutorialCommand);

            for (int i = 0; i < tutorialDataModel.TutorialSteps.Count; i++)
            {
                var step = tutorialDataModel.TutorialSteps[i];
                ITutorialCommand stepCommand = new NextStepTutorialCommand(step, m_tutorialPanelModel);
                m_tutorialCommandsQueue.Enqueue(stepCommand);
            }

            ITutorialCommand completeTutorialCommand = new CompleteTutorialCommand(tutorialDataModel, m_tutorialPanelModel, m_tutorialSystemModel);
            m_tutorialCommandsQueue.Enqueue(completeTutorialCommand);
            
            ProceedWithNextTutorialStep();
        }
    }
}