using System.Collections.Generic;
using TutorialProject.Infrastructure.TutorialSystem.Data.HighlightedData;

namespace TutorialProject.Infrastructure.TutorialSystem.Data.Models
{
    public class TutorialSystemModel
    {
        public int CurrentTutorialID = -1;
        public int CurrentStepIndex = -1;
        public bool IsTutorialActive = false;
        public List<IHighlightedTutorialElement> HighlightedObjects = new List<IHighlightedTutorialElement>();
    }
}