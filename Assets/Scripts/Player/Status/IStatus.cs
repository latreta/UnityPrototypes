using System.Collections;

namespace DefaultNamespace.Player.Status
{
    public interface IStatus
    {
        IEnumerator HandleBuff(Buff buff);
        void ApplyBuff(Buff buff);
    }
}