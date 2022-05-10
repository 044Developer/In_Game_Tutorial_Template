using System.Collections.Generic;
using TutorialProject.ApplicationBase;
using TutorialProject.Infrastructure.TutorialSystem.Commands;
using TutorialProject.Infrastructure.TutorialSystem.Data.HighlightedData;
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

        public bool StartTutorial(int tutorialID)
        {
            if (m_tutorialSystemModel.IsTutorialActive)
                return false;
            
            m_tutorialCommandsQueue.Clear();
            
            TutorialDataModel currentTutorial = m_tutorialDataBase.GetTutorial(tutorialID);

            if (currentTutorial.TutorialID < 0)
                return false;

            InitializeTutorial(currentTutorial);
            
            return true;
        }

        public void ProceedWithNextTutorialStep()
        {
            if (!m_tutorialSystemModel.IsTutorialActive)
                return;
            
            m_previousCommand?.Exit();

            m_previousCommand = m_tutorialCommandsQueue.Dequeue();
            
            m_previousCommand.Execute();
            
            ApplicationController.Instance.EventHolder.OnExecuteTutorialStep();
        }

        public void HighlightTutorialElements(List<IHighlightedTutorialElement> highlightedObjects)
        {
            m_tutorialSystemModel.HighlightedObjects.Clear();
            m_tutorialSystemModel.HighlightedObjects.AddRange(highlightedObjects);

            foreach (IHighlightedTutorialElement tutorialElement in m_tutorialSystemModel.HighlightedObjects)
                tutorialElement.HighlightElement();
        }

        public void DisposeCurrentTutorial()
        {
            m_previousCommand = null;
            m_tutorialCommandsQueue.Clear();
            m_tutorialSystemModel.HighlightedObjects.Clear();
            m_tutorialSystemModel.CurrentStepIndex = -1;
            m_tutorialSystemModel.IsTutorialActive = false;
            m_tutorialSystemModel.CurrentTutorialID = -1;
        }

        private void InitializeTutorial(TutorialDataModel tutorialDataModel)
        {
            ITutorialCommand startTutorialCommand = new StartTutorialCommand(tutorialDataModel, m_tutorialPanelModel, this);
            m_tutorialCommandsQueue.Enqueue(startTutorialCommand);

            for (int i = 0; i < tutorialDataModel.TutorialSteps.Count; i++)
            {
                var step = tutorialDataModel.TutorialSteps[i];
                ITutorialCommand stepCommand = new NextStepTutorialCommand(step, m_tutorialPanelModel, this);
                m_tutorialCommandsQueue.Enqueue(stepCommand);
            }

            ITutorialCommand completeTutorialCommand = new CompleteTutorialCommand(tutorialDataModel, m_tutorialPanelModel, this);
            m_tutorialCommandsQueue.Enqueue(completeTutorialCommand);
            
            ProceedWithNextTutorialStep();
        }
    }
}