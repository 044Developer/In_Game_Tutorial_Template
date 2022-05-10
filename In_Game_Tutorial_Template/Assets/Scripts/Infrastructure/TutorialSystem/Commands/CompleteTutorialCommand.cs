using TutorialProject.Infrastructure.TutorialSystem.Controller;
using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using TutorialProject.UI.TutorialPanel.Model;
using UnityEngine;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class CompleteTutorialCommand : ITutorialCommand
    {
        private const string TUTORIAL_SAVE_KEY = "Game_Tutorial_";
        
        private readonly TutorialDataModel m_tutorialDataModel;
        private readonly TutorialPanelModel m_tutorialPanelModel;
        private readonly TutorialSystemController m_tutorialSystemController;

        public CompleteTutorialCommand(TutorialDataModel tutorialDataModel, TutorialPanelModel tutorialPanelModel, TutorialSystemController tutorialSystemController)
        {
            m_tutorialDataModel = tutorialDataModel;
            m_tutorialPanelModel = tutorialPanelModel;
            m_tutorialSystemController = tutorialSystemController;
        }
        
        public void Execute()
        {
            DisposeCurrentEvent();

            DisposePanelView();
            
            SaveTutorial();
            
            Exit();
        }

        public void Exit()
        {
            m_tutorialSystemController.DisposeCurrentTutorial();
        }

        private void DisposeCurrentEvent()
        {
            m_tutorialSystemController.TutorialModel.IsTutorialActive = false;
            m_tutorialSystemController.TutorialModel.CurrentTutorialID = 0;
        }

        private void DisposePanelView()
        {
            m_tutorialPanelModel.ExecuteStepButton.gameObject.SetActive(false);
            m_tutorialPanelModel.FadeImage.gameObject.SetActive(false);
        }

        private void SaveTutorial()
        {
            if (HasCurrentTutorialSave())
                return;
            
            PlayerPrefs.SetInt($"{TUTORIAL_SAVE_KEY}{m_tutorialDataModel.TutorialID}", 1);
        }

        private bool HasCurrentTutorialSave()
        {
            bool hasSave = PlayerPrefs.HasKey($"{TUTORIAL_SAVE_KEY}{m_tutorialDataModel.TutorialID}");
            
            if (!hasSave) 
                return false;
            
            Debug.Log($"Tutorial - {m_tutorialDataModel.TutorialName} with ID:{m_tutorialDataModel.TutorialID} is already saved");
            return true;
        }
    }
}