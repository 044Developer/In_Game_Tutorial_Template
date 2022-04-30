using TutorialProject.Infrastructure.TutorialSystem.Data.Models;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class CompleteTutorialCommand : ITutorialCommand
    {
        private readonly TutorialDataModel m_tutorialDataModel;

        public CompleteTutorialCommand(TutorialDataModel tutorialDataModel)
        {
            m_tutorialDataModel = tutorialDataModel;
        }
        
        public void Execute()
        {
        }
    }
}