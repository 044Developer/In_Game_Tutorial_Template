using System.Collections.Generic;

namespace TutorialProject.Infrastructure.TutorialSystem.Data.Models
{
    public struct TutorialDataModel
    {
        public int TutorialID { get; }
        public string TutorialName { get; }
        public bool CanSkip { get; }
        public List<TutorialStepData> TutorialSteps { get; }

        public TutorialDataModel(int tutorialID = -1, string tutorialName = "", bool canSkip = false, List<TutorialStepData> tutorialSteps = null)
        {
            TutorialID = tutorialID;
            TutorialName = tutorialName;
            CanSkip = canSkip;
            TutorialSteps = tutorialSteps;
        }
    }
}