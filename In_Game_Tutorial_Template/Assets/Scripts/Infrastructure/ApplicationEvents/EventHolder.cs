using System;

namespace TutorialProject.Infrastructure.ApplicationEvents
{
    public class EventHolder
    {
        public Action OnExecuteTutorialStepEvent;
        public void OnExecuteTutorialStep()
        {
            var tempEvent = OnExecuteTutorialStepEvent;
            tempEvent?.Invoke();
        }
    }
}