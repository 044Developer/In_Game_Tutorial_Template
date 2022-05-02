using System.Collections.Generic;
using TutorialProject.Infrastructure.Tools.FileSystem.XMLFileReader;
using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using UnityEngine;

namespace TutorialProject.Infrastructure.TutorialSystem.TutorialDataBase
{
    public class TutorialDataBaseHolder : ITutorialDataBase
    {
        private XMLFileReader m_xmlFileReader = null;
        private List<TutorialDataModel> m_cashedTutorialData = null;
        
        public TutorialDataBaseHolder()
        {
            m_xmlFileReader = new XMLFileReader();
            m_cashedTutorialData = new List<TutorialDataModel>();
        }

        public void Initialize()
        {
            List<TutorialDataModel> tempData = m_xmlFileReader.ReadXMLTutorialModels();
            
            if (tempData is null || tempData.Count == 0)
                Debug.Log("Loaded tutorial data is null or empty");
            else
                m_cashedTutorialData.AddRange(tempData);
        }

        public void Dispose()
        {
            m_xmlFileReader.Dispose();
            m_cashedTutorialData.Clear();
        }

        public TutorialDataModel GetTutorial(int tutorialID)
        {
            return m_cashedTutorialData.Find(it => it.TutorialID == tutorialID);
        }

        public TutorialDataModel GetTutorial(string tutorialName)
        {
            return m_cashedTutorialData.Find(it => it.TutorialName == tutorialName);
        }
    }
}