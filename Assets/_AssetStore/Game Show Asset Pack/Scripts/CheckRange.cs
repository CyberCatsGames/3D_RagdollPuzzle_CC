using CodeBase.Enemies;
using UnityEngine;

namespace _AssetStore.Game_Show_Asset_Pack.Scripts
{
    public class CheckRange : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
        }

        private void TriggerEnter(Collider _)
        {
            _triggerObserver.TriggerEnter -= TriggerEnter;
            _agentMoveToPlayer.Enabled();
        }
    }
}