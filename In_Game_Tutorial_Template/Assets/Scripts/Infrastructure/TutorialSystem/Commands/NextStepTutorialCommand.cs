using TutorialProject.Infrastructure.TutorialSystem.Data.Models;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class NextStepTutorialCommand : ITutorialCommand
    {
        private readonly TutorialStepData m_tutorialStepData;

        public NextStepTutorialCommand(TutorialStepData tutorialStepData)
        {
            m_tutorialStepData = tutorialStepData;
        }
        
        public void Execute()
        {
        }
    }
}