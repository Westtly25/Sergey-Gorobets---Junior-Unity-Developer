using UnityEngine;

namespace Assets.Project.Code.Runtime.Architecture.Services.Save_Load_Service.Interface
{
    public interface IPersistentDataListener
    {
        public void LoadData(GameData gameData);
        public void SaveData(ref GameData gameData);
    }
}