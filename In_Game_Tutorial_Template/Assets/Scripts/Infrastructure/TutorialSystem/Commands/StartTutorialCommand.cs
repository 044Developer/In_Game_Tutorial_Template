using TutorialProject.Infrastructure.TutorialSystem.Data.Models;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class StartTutorialCommand : ITutorialCommand
    {
        private readonly TutorialDataModel m_tutorialDataModel;

        public StartTutorialCommand(TutorialDataModel tutorialDataModel)
        {
            m_tutorialDataModel = tutorialDataModel;
        }
        
        public void Execute()
        {
        }
    }
}