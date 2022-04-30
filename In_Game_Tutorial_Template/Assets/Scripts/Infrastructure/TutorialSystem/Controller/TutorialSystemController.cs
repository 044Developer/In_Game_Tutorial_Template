using System.Collections.Generic;
using TutorialProject.Infrastructure.TutorialSystem.Commands;
using TutorialProject.Infrastructure.TutorialSystem.TutorialDataBase;
using TutorialProject.UI.TutorialPanel.Model;

namespace TutorialProject.Infrastructure.TutorialSystem.Controller
{
    public class TutorialSystemController
    {
        private ITutorialDataBase m_tutorialDataBase = null;
        private TutorialPanelModel m_tutorialPanelModel = null;
        private Queue<ITutorialCommand> m_tutorialCommandsQueue = null;

        public TutorialSystemController(TutorialPanelModel tutorialPanelModel)
        {
            m_tutorialPanelModel = tutorialPanelModel;
            
            m_tutorialDataBase = new TutorialDataBaseHolder();
            m_tutorialCommandsQueue = new Queue<ITutorialCommand>();
        }

        public void Initialize()
        {
            m_tutorialDataBase.Initialize();
        }

        public void StartTutorial(int tutorialID)
        {
            m_tutorialCommandsQueue.Clear();
            
            var currentTutorial = m_tutorialDataBase.GetTutorial(tutorialID);

            ITutorialCommand startTutorialCommand = new StartTutorialCommand(currentTutorial);
            m_tutorialCommandsQueue.Enqueue(startTutorialCommand);

            for (int i = 0; i < currentTutorial.TutorialSteps.Count; i++)
            {
                var step = currentTutorial.TutorialSteps[i];
                ITutorialCommand stepCommand = new NextStepTutorialCommand(step);
                m_tutorialCommandsQueue.Enqueue(stepCommand);
            }

            ITutorialCommand completeTutorialCommand = new CompleteTutorialCommand(currentTutorial);
            m_tutorialCommandsQueue.Enqueue(completeTutorialCommand);
        }
    }
}