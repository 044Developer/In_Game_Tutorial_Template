using TutorialProject.Infrastructure.TutorialSystem.Data.Models;

namespace TutorialProject.Infrastructure.TutorialSystem.TutorialDataBase
{
    public interface ITutorialDataBase
    {
        void Initialize();
        void Dispose();
        TutorialDataModel GetTutorial(int tutorialID);
        TutorialDataModel GetTutorial(string tutorialName);
    }
}