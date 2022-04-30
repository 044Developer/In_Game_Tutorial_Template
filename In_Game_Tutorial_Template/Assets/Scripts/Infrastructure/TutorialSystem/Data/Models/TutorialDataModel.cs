using System.Collections.Generic;

namespace TutorialProject.Infrastructure.TutorialSystem.Data.Models
{
    public struct TutorialDataModel
    {
        public int TutorialID { get; }
        public string TutorialName { get; }
        public bool CanSkip { get; }
        public List<TutorialStepData> TutorialSteps { get; }

        public TutorialDataModel(int tutorialID, string tutorialName, bool canSkip, List<TutorialStepData> tutorialSteps)
        {
            TutorialID = tutorialID;
            TutorialName = tutorialName;
            CanSkip = canSkip;
            TutorialSteps = tutorialSteps;
        }
    }
}